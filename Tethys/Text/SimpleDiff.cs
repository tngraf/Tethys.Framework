#region Header
// --------------------------------------------------------------------------
// Tethys.Silverlight
// ==========================================================================
//
// This library contains common code for WPF, Silverlight, Windows Phone and
// Windows 8 projects.
//
// ===========================================================================
//
// <copyright file="SimpleDiff.cs" company="Tethys">
// Copyright  1998-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Text
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// SimpleDiff implements as simple LCS algorithm.
    /// LCS = Longest common subsequence, see this
    /// <a href="http://en.wikipedia.org/wiki/Longest_common_subsequence_problem#Computing_the_length_of_the_LCS">link</a>.
    /// for details.
    /// </summary>
    /// <remarks>
    /// Parts of this code are based on code of <c>Nish Sivakumar</c>. 
    /// The original article can be found here 
    /// <a href="http://www.codeproject.com/Articles/39184/An-LCS-based-diff-ing-library-in-C">
    /// link</a> and the original code is licensed by the Code Project Open 
    /// License (CPOL).
    /// </remarks>
    public class SimpleDiff
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Left side.
        /// </summary>
        private readonly string[] left;

        /// <summary>
        /// Right side.
        /// </summary>
        private readonly string[] right;

        /// <summary>
        /// The matrix.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
          "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member",
          Justification = "Best solution here.")]
        private int[,] matrix;

        /// <summary>
        /// Matrix creation flag.
        /// </summary>
        private bool matrixCreated;

        /// <summary>
        /// Pre skip value.
        /// </summary>
        private int preSkip;

        /// <summary>
        /// Post skip value.
        /// </summary>
        private int postSkip;
        #endregion // PRIVATE PROPERTIES

        //// --------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Line update event.
        /// </summary>
        public event EventHandler<DiffEventArgs> LineUpdate;
        #endregion // PUBLIC PROPERTIES

        //// --------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleDiff"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public SimpleDiff(string[] left, string[] right)
        {
            this.left = left;
            this.right = right;
        } // SimpleDiff()
        #endregion // CONSTRUCTION

        //// --------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// This is the sole public method and it initializes
        /// the LCS matrix the first time it's called, and 
        /// proceeds to fire a series of LineUpdate events
        /// </summary>
        public void RunDiff()
        {
            if (!this.matrixCreated)
            {
                this.CalculatePreSkip();
                this.CalculatePostSkip();
                this.CreateLcsMatrix();
            } // if

            for (var i = 0; i < this.preSkip; i++)
            {
                this.FireLineUpdate(DiffType.None, this.left[i], i);
            } // for

            var totalSkip = this.preSkip + this.postSkip;
            this.ShowDiff(this.left.Length - totalSkip, 
                this.right.Length - totalSkip);

            var leftLen = this.left.Length;
            for (var i = this.postSkip; i > 0; i--)
            {
                this.FireLineUpdate(DiffType.None, this.left[leftLen - i], 
                    leftLen - i);
            } // for
        } // RunDiff()
        #endregion // PUBLIC METHODS

        //// --------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// This method is an optimization that
        /// skips matching elements at the end of the 
        /// two arrays being compared.
        /// Care's taken so that this will never
        /// overlap with the pre-skip.
        /// </summary>
        private void CalculatePostSkip()
        {
            var leftLen = this.left.Length;
            var rightLen = this.right.Length;
            while (this.postSkip < leftLen && this.postSkip < rightLen &&
                this.postSkip < (leftLen - this.preSkip) &&
                StringCompare(this.left[leftLen - this.postSkip - 1], 
                this.right[rightLen - this.postSkip - 1]))
            {
                this.postSkip++;
            } // while
        } // CalculatePostSkip()

        /// <summary>
        /// This method is an optimization that
        /// skips matching elements at the start of
        /// the arrays being compared.
        /// </summary>
        private void CalculatePreSkip()
        {
            var leftLen = this.left.Length;
            var rightLen = this.right.Length;
            while (this.preSkip < leftLen && this.preSkip < rightLen &&
                StringCompare(this.left[this.preSkip], this.right[this.preSkip]))
            {
                this.preSkip++;
            } // while
        } // CalculatePreSkip()

#if true
        /// <summary>
        /// This traverses the elements using the LCS matrix
        /// and fires appropriate events for added, subtracted,
        /// and unchanged lines.
        /// It's recursively called till we run out of items.
        /// </summary>
        /// <param name="leftIndex">Index of the left.</param>
        /// <param name="rightIndex">Index of the right.</param>
        /// <remarks>
        /// Note: This is the improved non-recursive version.
        /// </remarks>
        private void ShowDiff(int leftIndex, int rightIndex)
        {
            var updates = new List<DiffEventArgs>();

            while (leftIndex > 0 || rightIndex > 0)
            {
                if (leftIndex > 0 && rightIndex > 0 &&
                    StringCompare(this.left[this.preSkip + leftIndex - 1],
                    this.right[this.preSkip + rightIndex - 1]))
                {
                    updates.Add(new DiffEventArgs(DiffType.None, 
                        this.left[this.preSkip + leftIndex - 1],
                        this.preSkip + leftIndex - 1));
                    leftIndex--;
                    rightIndex--;
                }
                else
                {
                    if (rightIndex > 0 &&
                        (leftIndex == 0 ||
                        this.matrix[leftIndex, rightIndex - 1] 
                        >= this.matrix[leftIndex - 1, rightIndex]))
                    {
                        updates.Add(new DiffEventArgs(DiffType.Add, 
                            this.right[this.preSkip + rightIndex - 1],
                            this.preSkip + rightIndex - 1));
                        rightIndex--;
                    }
                    else if (leftIndex > 0 &&
                      (rightIndex == 0 ||
                      this.matrix[leftIndex, rightIndex - 1] 
                        < this.matrix[leftIndex - 1, rightIndex]))
                    {
                        updates.Add(new DiffEventArgs(DiffType.Subtract, 
                            this.left[this.preSkip + leftIndex - 1],
                            this.preSkip + leftIndex - 1));
                        leftIndex--;
                    }
                }
            }

            for (var i = updates.Count - 1; i >= 0; i--)
            {
                var update = updates[i];
                FireLineUpdate(update.DiffType, update.LineValue,
                    update.LineIndex);
            } // for
        } // ShowDiff()
#else
        /// <summary>
        /// This traverses the elements using the LCS matrix
        /// and fires appropriate events for added, subtracted,
        /// and unchanged lines.
        /// It's recursively called till we run out of items.
        /// </summary>
        /// <param name="leftIndex">Index of the left.</param>
        /// <param name="rightIndex">Index of the right.</param>
        /// <remarks>
        /// Note: This is the original - RECURSIVE - version.
        /// </remarks>
        private void ShowDiff(int leftIndex, int rightIndex)
        {
            if (leftIndex > 0 && rightIndex > 0 &&
                StringCompare(this.left[this.preSkip + leftIndex - 1],
                this.right[this.preSkip + rightIndex - 1]))
            {
                this.ShowDiff(leftIndex - 1, rightIndex - 1);
                this.FireLineUpdate(DiffType.None,
                  this.left[this.preSkip + leftIndex - 1],
                  this.preSkip + leftIndex - 1);
            }
            else
            {
                if (rightIndex > 0 &&
                    (leftIndex == 0 ||
                     this.matrix[leftIndex, rightIndex - 1] >= 
                     this.matrix[leftIndex - 1, rightIndex]))
                {
                    this.ShowDiff(leftIndex, rightIndex - 1);
                    this.FireLineUpdate(DiffType.Add, 
                      this.right[this.preSkip + rightIndex - 1],
                      this.preSkip + rightIndex - 1);
                }
                else if (leftIndex > 0 && (rightIndex == 0 ||
                      this.matrix[leftIndex, rightIndex - 1] < 
                      this.matrix[leftIndex - 1, rightIndex]))
                {
                    this.ShowDiff(leftIndex - 1, rightIndex);
                    this.FireLineUpdate(DiffType.Subtract, 
                      this.left[this.preSkip + leftIndex - 1],
                      this.preSkip + leftIndex - 1);
                } // if
            } // if
        } // ShowDiff()
#endif

        /// <summary>
        /// This is the core method in the entire class,
        /// and uses the standard LCS calculation algorithm.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
        "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Body",
         Justification = "Best solution here.")]
        private void CreateLcsMatrix()
        {
            var totalSkip = this.preSkip + this.postSkip;
            if (totalSkip >= this.left.Length || totalSkip >= this.right.Length)
            {
                return;
            } // if

            // We only create a matrix large enough for the
            // unskipped contents of the diff'ed arrays
            this.matrix = new int[this.left.Length - totalSkip + 1,
                this.right.Length - totalSkip + 1];

            for (var i = 1; i <= this.left.Length - totalSkip; i++)
            {
                // Simple optimization to avoid this calculation
                // inside the outer loop (may have got JIT optimized 
                // but my tests showed a minor improvement in speed)
                var leftIndex = this.preSkip + i - 1;

                // Again, instead of calculating the adjusted index inside
                // the loop, I initialize it under the assumption that
                // incrementing will be a faster operation on most CPUs
                // compared to addition. Again, this may have got JIT
                // optimized but my tests showed a minor speed difference.
                for (int j = 1, rightIndex = this.preSkip + 1; 
                    j <= this.right.Length - totalSkip; j++, rightIndex++)
                {
                    this.matrix[i, j] = StringCompare(this.left[leftIndex],
                        this.right[rightIndex - 1]) ?
                        this.matrix[i - 1, j - 1] + 1 :
                        Math.Max(this.matrix[i, j - 1], this.matrix[i - 1, j]);
                } // for
            } // for

            this.matrixCreated = true;
        } // CreateLCSMatrix()

        /// <summary>
        /// Fires the line update.
        /// </summary>
        /// <param name="diffType">Type of the diff.</param>
        /// <param name="lineValue">The line value.</param>
        /// <param name="index">The index.</param>
        private void FireLineUpdate(DiffType diffType, string lineValue,
            int index)
        {
            var local = this.LineUpdate;

            if (local == null)
            {
                return;
            } // if

            local(this, new DiffEventArgs(diffType, lineValue, index));
        } // FireLineUpdate()

        /// <summary>
        /// This comparison is specifically
        /// for strings, and was nearly thrice as
        /// fast as the default comparison operation.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>A value indicating whether both string are the same.</returns>
        private static bool StringCompare(string left, string right)
        {
            return Equals(left, right);
        } // StringCompare()
        #endregion // PRIVATE METHODS
    } // SimpleDiff
} // Tethys.Text.Diff

// ====================
// End of SimpleDiff.cs
// ====================
