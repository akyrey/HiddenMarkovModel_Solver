//======================================================================
// Class: HiddenMarkovModel
// Author: Dario Vogogna
// Date: November 2015
//======================================================================

using System;
using MathNet.Numerics.Random;
using System.Collections.Generic;

namespace HMM_Solve
{
    /// <summary>
    ///     Hidden Markov Model
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    ///     Hidden Markov Models (HMM) are stochastic methods to model temporal and sequence
    ///     data. They are especially known for their application in temporal pattern recognition
    ///     such as speech, handwriting, gesture recognition, part-of-speech tagging, musical
    ///     score following, partial discharges and bioinformatics.
    /// </para>
    /// <para>
    ///     Dynamical systems of discrete nature assumed to be governed by a Markov chain emits
    ///     a sequence of observable outputs. Under the Markov assumption, it is also assumed that
    ///     the latest output depends only on the current state of the system. Such states are often
    ///     not known from the observer when only the output values are observable.
    /// </para>
    ///   
    /// <para>
    ///     Hidden Markov Models attempt to model such systems and allow, among other things,
    ///     <list type="number">
    ///         <item><description>
    ///             To infer the most likely sequence of states that produced a given output sequence,
    ///         </description></item>
    ///         <item><description>
    ///             Infer which will be the most likely next state (and thus predicting the next output),
    ///         </description></item>
    ///         <item><description>
    ///             Calculate the probability that a given sequence of outputs originated from the system
    ///             (allowing the use of hidden Markov models for sequence classification).
    ///         </description></item>
    ///     </list>
    /// </para>
    ///     
    /// <para>     
    ///     The “hidden” in Hidden Markov Models comes from the fact that the observer does not
    ///     know in which state the system may be in, but has only a probabilistic insight on where
    ///     it should be.
    /// </para>
    /// 
    /// <para>
    ///     References:
    ///     <list type="bullet">
    ///         <item><description>
    ///             http://en.wikipedia.org/wiki/Hidden_Markov_model
    ///         </description></item>
    ///         <item><description>
    ///             http://www.codeproject.com/Articles/69647/Hidden-Markov-Models-in-C
    ///         </description></item>
    ///         <item><description>
    ///             https://webdocs.cs.ualberta.ca/~lindek/hmm.htm
    ///         </description></item>
    ///         <item><description>
    ///             http://www.codeproject.com/Articles/673055/Generic-Sparse-Array-and-Sparse-Matrices-in-Csharp
    ///         </description></item>
    ///         <item><description>
    ///             http://alumni.media.mit.edu/~rahimi/rabiner/rabiner-errata/
    ///         </description></item>
    ///     </list>
    /// </para>
    /// </remarks>
    class HiddenMarkovModel
    {
        private MySparse2DMatrix A;  // Transition probabilities
        private MySparse2DMatrix B;  // Emission probabilities
        private double[] Pi;    // Initial state probabilities
        private int states;     // Number of states
        private int symbols;    // Number of emission symbols

        private TemporalState[] tempInstancts;

        /* Adding an object for each time slice */
        public class TemporalState
        {
            public double c; // Scaling factor
            public int[] State { get; set; }
            public double[] Alpha { get; set; }
            public double[] Beta { get; set; }
            public double[] Gamma { get; set; }
            public double[] Delta { get; set; }
            public MySparse2DMatrix Xi { get; set; }

            /// <summary>
            ///     Constructs a new State associating all computed variables.
            /// </summary>
            /// <param name="states">Number of observations.</param>
            public TemporalState(int states)
            {
                Alpha = new double[states];
                Beta = new double[states];
                Gamma = new double[states];
                Delta = new double[states];
                State = new int[states];
                Xi = new MySparse2DMatrix();
            }
        }

        #region Constructor

        /// <summary>
        ///     Constructs a new Hidden Markov Model.
        /// </summary>
        /// <param name="transitions">The transitions matrix A for this model.</param>
        /// <param name="emissions">The emissions matrix B for this model.</param>
        /// <param name="probabilities">The initial state probabilities for this model.</param>
        public HiddenMarkovModel(MySparse2DMatrix transitions, MySparse2DMatrix emissions, double[] probabilities, int emissionSymbols)
        {
            A = transitions;
            B = emissions;
            Pi = probabilities;
            states = Pi.Length;
            symbols = emissionSymbols;
            tempInstancts = null;
        }

        #endregion

        #region Public properties

        /// <summary>
        ///     Gets the Transition matrix (A) for this model.
        /// </summary>
        public MySparse2DMatrix Transitions
        {
            get { return A; }
        }

        /// <summary>
        ///     Gets the Emission matrix (B) for this model.
        /// </summary>
        public MySparse2DMatrix Emissions
        {
            get { return B; }
        }

        /// <summary>
        ///     Gets the initial probabilities (Pi) for this model.
        /// </summary>
        public double[] Probabilities
        {
            get { return Pi; }
        }

        /// <summary>
        ///     Gets the number of states of this model.
        /// </summary>
        public int States
        {
            get { return states; }
        }

        /// <summary>
        ///     Gets the number of emission symbols of this model.
        /// </summary>
        public int Symbols
        {
            get { return symbols; }
        }

        /// <summary>
        ///     CHECK
        /// </summary>
        public TemporalState[] Instancts
        {
            get { return tempInstancts; }
        }

        #endregion

        #region Public methods

        /// <summary>
        ///   Initialize the temporalInstancts variable to the
        ///   length of the observation sequence.
        /// </summary>
        /// <param name="observations">
        ///   A sequence of observations.
        /// </param>
        public void InitializeObservation(int[] observations)
        {
            int T = observations.Length;
            tempInstancts = new TemporalState[T];
            for (int t = 0; t < T; t++)
            {
                tempInstancts[t] = new TemporalState(States);
            }
        }

        /// <summary>
        ///   Calculates the probability that this model has generated the given sequence.
        /// </summary>
        /// <remarks>
        ///   Evaluation problem. Given the HMM  M = (A, B, pi) and  the observation
        ///   sequence O = {o1, o2, ..., oK}, calculate the probability that model
        ///   M has generated sequence O. This can be computed efficiently using
        ///   the Forward algorithms.
        /// </remarks>
        /// <param name="observations">
        ///   A sequence of observations.
        /// </param>
        /// <returns>
        ///   The probability that the given sequence has been generated by this model.
        /// </returns>
        public double Evaluate(int[] observations)
        {
            return Evaluate(observations, false);
        }

        /// <summary>
        ///   Calculates the probability that this model has generated the given sequence.
        /// </summary>
        /// <remarks>
        ///   Evaluation problem. Given the HMM  M = (A, B, pi) and  the observation
        ///   sequence O = {o1, o2, ..., oK}, calculate the probability that model
        ///   M has generated sequence O. This can be computed efficiently using
        ///   the Forward or Backward algorithms.
        /// </remarks>
        /// <param name="observations">
        ///   A sequence of observations.
        /// </param>
        /// <param name="useBackward">
        ///   False to return the Forward algorithm result,
        ///   True to return the Backward algorithm result.
        ///   Default is false.
        /// </param>
        /// <returns>
        ///   The probability that the given sequence has been generated by this model.
        /// </returns>
        public double Evaluate(int[] observations, bool useBackward)
        {
            if (observations.Length == 0)
                return 0.0;

            // Forward algorithm
            double forwardResult = forward(observations);
            if (useBackward)
            {
                // Backward algorithm (need to call first forward algorithm to calculate scale factors)
                return backward(observations);
            }

            return forwardResult;
        }

        /// <summary>
        ///   Calculates the most likely sequence of hidden states
        ///   that produced the given observation sequence.
        /// </summary>
        /// <remarks>
        ///   Decoding problem. Given the HMM M = (A, B, pi) and  the observation sequence 
        ///   O = {o1,o2, ..., oK}, calculate the most likely sequence of hidden states Si
        ///   that produced this observation sequence O. This can be computed efficiently
        ///   using the Viterbi algorithm.
        /// </remarks>
        /// <param name="observations">A sequence of observations.</param>
        /// <param name="probability">The state optimized probability.</param>
        /// <returns>The sequence of states that most likely produced the sequence.</returns>
        public int[] MostLikelyPath(int[] observations, out double probability)
        {
            return viterbi(observations, out probability);
        }

        /// <summary>
        ///   Runs the Baum-Welch learning algorithm for hidden Markov models.
        /// </summary>
        /// <remarks>
        ///   Learning problem. Given some training observation sequences O = {o1, o2, ..., oK}
        ///   and general structure of HMM (numbers of hidden and visible states), determine
        ///   HMM parameters M = (A, B, pi) that best fit training data. 
        /// </remarks>
        /// <param name="observations">
        ///   The sequence of observations to be used to train the model.
        /// </param>
        public void Learn(int[] observations)
        {
            Learn(new int[][] { observations }, 10);
        }

        /// <summary>
        ///   Runs the Baum-Welch learning algorithm for hidden Markov models.
        /// </summary>
        /// <remarks>
        ///   Learning problem. Given some training observation sequences O = {o1, o2, ..., oK}
        ///   and general structure of HMM (numbers of hidden and visible states), determine
        ///   HMM parameters M = (A, B, pi) that best fit training data. 
        /// </remarks>
        /// <param name="observations">
        ///   An array of sequences of observations to be used to train the model.
        /// </param>
        public void Learn(int[][] observations)
        {
            Learn(observations, 10);
        }

        /// <summary>
        ///   Runs the Baum-Welch learning algorithm for hidden Markov models.
        /// </summary>
        /// <remarks>
        ///   Learning problem. Given some training observation sequences O = {o1, o2, ..., oK}
        ///   and general structure of HMM (numbers of hidden and visible states), determine
        ///   HMM parameters M = (A, B, pi) that best fit training data. 
        /// </remarks>
        /// <param name="observations">
        ///   The sequence of observations to be used to train the model.
        /// </param>
        /// <param name="iterations">
        ///   The maximum number of iterations to be performed by the learning algorithm.
        /// </param>
        public void Learn(int[] observations, int iterations)
        {
            Learn(new int[][] { observations }, iterations);
        }

        /// <summary>
        ///   Runs the Baum-Welch learning algorithm for hidden Markov models.
        /// </summary>
        /// <remarks>
        ///   Learning problem. Given some training observation sequences O = {o1, o2, ..., oK}
        ///   and general structure of HMM (numbers of hidden and visible states), determine
        ///   HMM parameters M = (A, B, pi) that best fit training data. 
        /// </remarks>
        /// <param name="observations">
        ///   An array of sequences of observations to be used to train the model.
        /// </param>
        /// <param name="iterations">
        ///   The maximum number of iterations to be performed by the learning algorithm.
        /// </param>
        public void Learn(int[][] observations, int iterations)
        {
            for (int i = 0; i < iterations; i++)
                baum_welch(observations);
        }

        /// <summary>
        ///   Generates the given number of observations.
        /// </summary>
        /// <param name="seqNum">Number of sequences wanted.</param>
        /// <returns>All the generated sequences.</returns>
        public int[][] generateSequence(int seqNum)
        {
            var result = new int[seqNum][];
            for (int i = 0; i < seqNum; i++)
            {
                result[i] = generateSingleSeq();
            }

            return result;
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Forward algorithm (with scaling)
        /// </summary>
        /// <param name="observations">A sequence of observations.</param>
        /// <returns></returns>
        private double forward(int[] observations)
        {
            if (observations == null)
                throw new ArgumentNullException("observations");

            if (tempInstancts == null)
                throw new ArgumentNullException("tempInstancts");

            int T = observations.Length;

            // 1. Initialization
            for (int i = 0; i < States; i++)
                tempInstancts[0].c += tempInstancts[0].Alpha[i] = Probabilities[i] * Emissions.getValue(i, observations[0]);

            if (tempInstancts[0].c != 0) // Scaling CHECK
            {
                for (int i = 0; i < States; i++)
                    tempInstancts[0].Alpha[i] = tempInstancts[0].Alpha[i] / tempInstancts[0].c;
            }

            // 2. Induction
            for (int t = 1; t < T; t++)
            {
                for (int i = 0; i < States; i++)
                {
                    double sum = 0.0;

                    for (int k = 0; k < States; k++)
                        sum += (tempInstancts[t - 1].Alpha[k] * Transitions.getValue(k, i));

                    tempInstancts[t].Alpha[i] = sum * Emissions.getValue(i, observations[t]);

                    tempInstancts[t].c += tempInstancts[t].Alpha[i]; // Scaling coefficient
                }

                if (tempInstancts[t].c != 0) // Scaling
                {
                    for (int i = 0; i < States; i++)
                        tempInstancts[t].Alpha[i] = tempInstancts[t].Alpha[i] / tempInstancts[t].c;
                }
            }

            // 3. Termination
            double POGivenLambdaScaled = 0.0;
            for (int i = 0; i < Probabilities.Length; i++)
                POGivenLambdaScaled += tempInstancts[T - 1].Alpha[i];

            double scaling = 1.0;
            for (int t = 0; t < T; t++)
                scaling *= tempInstancts[t].c;

            var POGivenLambda = POGivenLambdaScaled * scaling;

            return POGivenLambda;
        }

        /// <summary>
        ///     Backward algorithm (without scaling)
        /// </summary>
        /// <param name="observations">A sequence of observations.</param>
        /// <returns></returns>
        private double backward(int[] observations)
        {
            if (observations == null)
                throw new ArgumentNullException("observations");

            if (tempInstancts == null)
                throw new ArgumentNullException("tempInstancts");

            int T = observations.Length;

            // For beta variables, I use the same scale factors
            //   for each time t as I used for alpha variables.

            // 1. Initialization
            for (int i = 0; i < States; i++)
                tempInstancts[T - 1].Beta[i] = 1.0 / tempInstancts[T - 1].c;

            // 2. Induction
            for (int t = T - 2; t >= 0; t--)
            {
                for (int i = 0; i < States; i++)
                {
                    double sum = 0.0;

                    for (int j = 0; j < States; j++)
                        sum += (Transitions.getValue(i, j) * Emissions.getValue(j, observations[t + 1]) * tempInstancts[t + 1].Beta[j]);

                    tempInstancts[t].Beta[i] += sum / tempInstancts[t].c;
                }
            }

            // 3. Termination
            double POGivenLambdaScaled = 0.0;
            for (int i = 0; i < Probabilities.Length; i++)
                POGivenLambdaScaled += Probabilities[i] * Emissions.getValue(i, observations[0]) * tempInstancts[0].Beta[i];

            double scaling = 1.0;
            for (int t = 0; t < T; t++)
                scaling *= tempInstancts[t].c;

            var POGivenLambda = POGivenLambdaScaled * scaling;

            return POGivenLambda;
        }

        /// <summary>
        ///     Calculates the most likely sequence of hidden states
        ///     that produced the given observation sequence.
        /// </summary>
        /// <remarks>
        ///     Decoding problem. Given the HMM M = (A, B, pi) and  the observation sequence 
        ///     O = {o1,o2, ..., oK}, calculate the most likely sequence of hidden states Si
        ///     that produced this observation sequence O. This can be computed efficiently
        ///     using the Viterbi algorithm.
        /// </remarks>
        /// <param name="observations">A sequence of observations.</param>
        /// <param name="probability">The state optimized probability.</param>
        /// <returns>The sequence of states that most likely produced the sequence.</returns>
        private int[] viterbi(int[] observations, out double probability)
        {
            if (observations == null)
                throw new ArgumentNullException("observations");

            if (tempInstancts == null)
                throw new ArgumentNullException("tempInstancts");

            if (observations.Length == 0)
            {
                probability = 0.0;
                return new int[0];
            }

            int T = observations.Length;
            double maxWeight;
            int maxState;

            // 1. Base
            for (int i = 0; i < States; i++)
                tempInstancts[0].Delta[i] = Probabilities[i] * Emissions.getValue(i, observations[0]);

            // 2. Induction
            for (int t = 1; t < T; t++)
            {
                for (int i = 0; i < States; i++)
                {
                    maxWeight = 0.0;
                    maxState = 0;

                    for (int k = 0; k < States; k++)
                    {
                        double weight = tempInstancts[t - 1].Delta[k] * Transitions.getValue(k, i);

                        if (weight > maxWeight)
                        {
                            maxWeight = weight;
                            maxState = k;
                        }
                    }

                    tempInstancts[t].Delta[i] = maxWeight * Emissions.getValue(i, observations[t]);
                    tempInstancts[t].State[i] = maxState;
                }
            }

            // Find maximum value for time T-1
            maxWeight = tempInstancts[T - 1].Delta[0];
            maxState = 0;

            for (int k = 1; k < States; k++)
            {
                if (tempInstancts[T - 1].Delta[k] > maxWeight)
                {
                    maxWeight = tempInstancts[T - 1].Delta[k];
                    maxState = k;
                }
            }

            // Trackback
            int[] path = new int[T];
            path[T - 1] = maxState;

            for (int t = T - 2; t >= 0; t--)
                path[t] = tempInstancts[t + 1].State[path[t + 1]];

            // Returns the sequence probability as an out parameter
            probability = maxWeight;

            // Returns the most likely (Viterbi path) for the given sequence
            return path;
        }

        /// <summary>
        ///     Runs the Baum-Welch learning algorithm for hidden Markov models.
        /// </summary>
        /// <remarks>
        ///     Learning problem. Given a training observation sequence O = {o1, o2, ..., oK}
        ///     and general structure of HMM (numbers of hidden and visible states), determine
        ///     HMM parameters M = (A, B, pi) that best fit training data. 
        /// </remarks>
        /// <para>
        ///     The Baum–Welch algorithm is a particular case of a generalized expectation-maximization
        ///     (GEM) algorithm. It can compute maximum likelihood estimates and posterior mode estimates
        ///     for the parameters (transition and emission probabilities) of an HMM, when given only
        ///     emissions as training data.
        /// </para>
        /// 
        /// <para>
        ///     The algorithm has two steps:
        ///         - Calculating the forward probability and the backward probability for each HMM state;
        ///         - On the basis of this, determining the frequency of the transition-emission pair values
        ///           and dividing it by the probability of the entire string. This amounts to calculating
        ///           the expected count of the particular transition-emission pair. Each time a particular
        ///           transition is found, the value of the quotient of the transition divided by the probability
        ///           of the entire string goes up, and this value can then be made the new value of the transition.
        /// </para>
        /// <param name="observations">A sequence of observations.</param>
        /// <returns></returns>
        private void baum_welch(int[][] observations)
        {
            if (observations == null)
                throw new ArgumentNullException("observations");

            int N = observations.Length;
            var multipleTempInstants = new TemporalState[N][];

            for (int k = 0; k < N; k++)
            {
                // 1. Calculating the forward probability and the
                //    backward probability for each HMM state.
                InitializeObservation(observations[k]);
                forward(observations[k]);
                backward(observations[k]);

                int T = observations[k].Length;

                // 2. Determining the frequency of the transition-emission pair values
                //    and dividing it by the probability of the entire string.
                // Calculate gamma values
                update(T);

                // Calculate xi
                for (int t = 0; t < T - 1; t++)
                    tempInstancts[t].Xi = calcXi(t, observations[k][t + 1]);

                multipleTempInstants[k] = tempInstancts;
            }

            // 3. Continue with parameter re-estimation
            // 3.1 Re-estimation of initial state probabilities 
            for (int i = 0; i < States; i++)
            {
                double sum = 0;
                for (int k = 0; k < N; k++)
                    sum += multipleTempInstants[k][0].Gamma[i];
                Probabilities[i] = sum / N;
            }

            // 3.2 Re-estimation of transition probabilities 
            for (int i = 0; i < States; i++)
            {
                for (int j = 0; j < States; j++)
                {
                    double den = 0, num = 0;

                    for (int k = 0; k < N; k++)
                    {
                        int T = observations[k].Length;

                        for (int t = 0; t < T - 1; t++)
                        {
                            num += multipleTempInstants[k][t].Xi.getValue(i, j);
                            den += multipleTempInstants[k][t].Gamma[i];
                        }
                    }

                    // Remove from the matrix if needed
                    if (den != 0)
                    {
                        double result = num / den;
                        if (result != 0)
                            Transitions.setValue(i, j, result);
                        else
                            Transitions.Remove(i, j);
                    }
                    else
                        Transitions.Remove(i, j);
                }
            }

            // 3.3 Re-estimation of emission probabilities
            for (int i = 0; i < States; i++)
            {
                for (int j = 0; j < Symbols; j++)
                {
                    double den = 0, num = 0;

                    for (int k = 0; k < N; k++)
                    {
                        int T = observations[k].Length;

                        for (int t = 0; t < T; t++)
                        {
                            if (observations[k][t] == j)
                                num += multipleTempInstants[k][t].Gamma[i];
                        }

                        for (int t = 0; t < T; t++)
                            den += multipleTempInstants[k][t].Gamma[i];
                    }

                    // Remove from the matrix if needed
                    if (num != 0)
                        Emissions.setValue(i, j, num / den);
                    else
                        Emissions.Remove(i, j);
                }
            }
        }

        /// <summary>
        ///     Determining the frequency of the transition-emission pair values
        ///     and dividing it by the probability of the entire string.
        ///     
        ///     Using the scaled values I don't need to divide by the probability
        ///     of the entire string but just for the rescaled factor at the same time
        /// </summary>
        /// <param name="T">Observations length.</param>
        /// <returns>Probability of being in each state at each time</returns>
        private void update(int T)
        {
            if (tempInstancts == null)
                throw new ArgumentNullException("tempInstancts");

            for (int t = 0; t < T; t++)
            {
                double s = 0;

                if (tempInstancts[t].Alpha == null || tempInstancts[t].Beta == null)
                    throw new ArgumentNullException("Alpha and Beta aren't set");

                for (int i = 0; i < States; i++)
                    s += tempInstancts[t].Gamma[i] = (tempInstancts[t].Alpha[i] * tempInstancts[t].Beta[i]);

                if (s != 0) // Scaling
                {
                    for (int k = 0; k < States; k++)
                        tempInstancts[t].Gamma[k] /= s;
                }
            }
        }

        /// <summary>
        ///     Determining the frequency of the transition-emission pair values
        ///     and dividing it by the probability of the entire string.
        ///     
        ///     Using the scaled values, I don't need to divide it for the
        ///     probability of the entire string anymore
        /// </summary>
        /// <param name="t">Current time.</param>
        /// <param name="nextObservation">Observation at time t + 1.</param>
        /// <returns>Probability of transition from each state to any other at time t</returns>
        private MySparse2DMatrix calcXi(int t, int nextObservation)
        {
            if (tempInstancts == null)
                throw new ArgumentNullException("tempInstancts");

            if (tempInstancts[t].Alpha == null || tempInstancts[t].Beta == null)
                throw new ArgumentNullException("Alpha and Beta aren't set");

            MySparse2DMatrix currentXi = new MySparse2DMatrix();

            double s = 0;

            for (int i = 0; i < States; i++)
            {
                for (int j = 0; j < States; j++)
                {
                    double temp = tempInstancts[t].Alpha[i] * Transitions.getValue(i, j) * Emissions.getValue(j, nextObservation) * tempInstancts[t + 1].Beta[j];
                    s += temp;
                    if (temp != 0)
                        currentXi.setValue(i, j, temp);
                }
            }

            if (s != 0) // Scaling
            {
                for (int i = 0; i < States; i++)
                {
                    for (int j = 0; j < States; j++)
                    {
                        if (currentXi.getValue(i, j) != 0)
                            currentXi.setValue(i, j, currentXi.getValue(i, j) / s);
                    }
                }
            }

            return currentXi;
        }

        /// <summary>
        ///     Calculates the transition to the next state.
        /// </summary>
        /// <returns>The next state.</returns>
        private int[] generateSingleSeq()
        {
            var tempList = new List<int>();

            var currentState = randomExtraction(Pi);

            do
            {
                tempList.Add(randomExtraction(currentState, Emissions));
                currentState = randomExtraction(currentState, Transitions);
            } while (currentState != -1);

            return tempList.ToArray();
        }

        /// <summary>
        ///     Returns a random index of the input array using the given distribution.
        /// </summary>
        /// <param name="probabilities">Distribution probability.</param>
        /// <returns>Random index of the input array.</returns>
        private int randomExtraction (double[] probabilities)
        {
            var rand = SystemRandomSource.Default;
            var extraction = rand.NextDouble();

            for (int i = 0; i < probabilities.Length; i++)
            {
                if (extraction < probabilities[i])
                    return i;
                extraction -= probabilities[i];
            }

            return -1;
        }

        /// <summary>
        ///     Returns a random index of the matrix state column using the given distribution.
        /// </summary>
        /// <param name="state">Current state.</param>
        /// <param name="matrix">Probability distribution matrix.</param>
        /// <returns>Random index of the matrix state column.</returns>
        private int randomExtraction(int state, MySparse2DMatrix matrix)
        {
            var rand = SystemRandomSource.Default;
            var extraction = rand.NextDouble();

            for (int i = 0; i < Symbols; i++)
            {
                if (extraction < matrix.getValue(state, i))
                    return i;
                extraction -= matrix.getValue(state, i);
            }

            return -1;
        }

        #endregion
    }
}