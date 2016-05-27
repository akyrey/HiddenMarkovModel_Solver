using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HMM_Solve
{
    public partial class MainForm : Form
    {
        HiddenMarkovModel hmm;
        MySparse2DMatrix A, B;
        List<double> Pi;
        List<string> piSymbols;
        List<List<int>> observationsList;
        Id2Str stateSymbols, emissionsSymbols;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Implemented methods

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Application.Exit();
        }

        private void openTransition_Click(object sender, EventArgs e)
        {
            // Set filter options and filter index.
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Transition Files (.trans)|*.trans|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var firstLine = true;
                string line, firstState = "INIT";
                A = new MySparse2DMatrix();
                Pi = new List<double>();
                piSymbols = new List<string>();
                stateSymbols = new Id2Str();

                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName);
                transitionsRichTextBox.Text = "";

                while ((line = sr.ReadLine()) != null)
                {
                    transitionsRichTextBox.Text += line + "\n";
                    if (firstLine)
                    {
                        firstState = line;
                        firstLine = false;
                    }
                    else
                    {
                        string[] stateValue = line.Split('\t');
                        if (stateValue.Length == 3)
                        {
                            if (stateValue[0] == firstState)
                            {
                                stateSymbols.setId(stateValue[1]);
                                piSymbols.Add(stateValue[1]);
                                Pi.Add(Double.Parse(stateValue[2], CultureInfo.InvariantCulture));
                            }
                            else
                            {
                                int row = stateSymbols.setId(stateValue[0]);
                                int col = stateSymbols.setId(stateValue[1]);
                                A.setValue(row, col, Double.Parse(stateValue[2], CultureInfo.InvariantCulture));
                                // Still need to add states to pi with probability 0
                                if (!piSymbols.Contains(stateValue[0]))
                                {
                                    piSymbols.Add(stateValue[0]);
                                    Pi.Add(0.0);
                                }
                                if (!piSymbols.Contains(stateValue[1]))
                                {
                                    piSymbols.Add(stateValue[1]);
                                    Pi.Add(0.0);
                                }
                            }
                        }
                    }
                }
                sr.Close();
                if (A.Count > 0)
                {
                    buttonOpenEmissions.Enabled = true;
                    openEmissionsToolStripMenuItem.Enabled = true;
                }
                else
                {
                    buttonOpenEmissions.Enabled = false;
                    openEmissionsToolStripMenuItem.Enabled = false;
                    MessageBox.Show("Error! Parsed transitions matrix resulted empty. Check your input file please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openEmissions_Click(object sender, EventArgs e)
        {
            // Set filter options and filter index.
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Emission Files (.emit)|*.emit|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string line;
                B = new MySparse2DMatrix();
                emissionsSymbols = new Id2Str();
                var separator = '\t';

                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName);
                emissionsRichTextBox.Text = "";

                if ((line = sr.ReadLine()) != null)
                {
                    if (line.Split(separator).Length == 1)
                        separator = ' ';
                    sr.DiscardBufferedData();
                    sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                    sr.BaseStream.Position = 0;
                }

                while ((line = sr.ReadLine()) != null)
                {
                    emissionsRichTextBox.Text += line + "\n";

                    string[] stateValue = line.Split(separator);
                    if (stateValue.Length == 3)
                    {
                        int row = stateSymbols.setId(stateValue[0]);
                        int col = emissionsSymbols.setId(stateValue[1]);
                        B.setValue(row, col, Double.Parse(stateValue[2], CultureInfo.InvariantCulture));
                    }
                }
                sr.Close();
                if (B.Count > 0)
                {
                    buttonCreateHMM.Enabled = true;
                    openObservationsToolStripMenuItem.Enabled = true;
                }
                else
                {
                    buttonCreateHMM.Enabled = false;
                    openObservationsToolStripMenuItem.Enabled = false;
                    MessageBox.Show("Error! Parsed emissions matrix resulted empty. Check your input file please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void createHMM_Click(object sender, EventArgs e)
        {
            hmm = new HiddenMarkovModel(A, B, Pi.ToArray(), emissionsSymbols.Symbols);

            tabControl1.SelectedTab = computationTab;
        }

        private void loadObservations_Click(object sender, EventArgs e)
        {
            if (hmm == null)
            {
                MessageBox.Show("Error! You need to first create the HMM", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Set filter options and filter index.
                openFileDialog.FileName = "";
                openFileDialog.Filter = "Observations Files (.train, .input)|*.train;*.input|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;


                // Call the ShowDialog method to show the dialog box.
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int count = 1;
                    string line;
                    observationsRichTextBox.Text = "";
                    observationsList = new List<List<int>>();
                    System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName);

                    while ((line = sr.ReadLine()) != null)
                    {
                        bool error = false;
                        List<int> observations = new List<int>();
                        string[] observationsLine = line.Split(' ');
                        foreach (var item in observationsLine)
                        {
                            int emission;
                            // If the symbol exists in the current model
                            if (item != "")
                            {
                                if ((emission = emissionsSymbols.getId(item)) != -1)
                                    observations.Add(emission);
                                else {
                                    MessageBox.Show("Error while reading symbol " + item + " in line" + count + "!\nSkipping this line", "Error", MessageBoxButtons.OKCancel);
                                    error = true;
                                    break;
                                }
                            }
                        }

                        if (!error)
                        {
                            observationsList.Add(observations);
                            observationsRichTextBox.Text += line + "\n";
                        }

                        count++;
                    }
                }

            }
        }

        private void evaluate_CheckedChanged(object sender, EventArgs e)
        {
            if (evaluateCheckBox.Checked)
                forwardButton.Enabled = backwardButton.Enabled = true;
            else
                forwardButton.Enabled = backwardButton.Enabled = false;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (emissionsSymbols == null)
            {
                MessageBox.Show("Error! You need to first create the HMM", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var sequences = hmm.generateSequence((int)numSeq.Value);

                resultRichTextBox.Text += "Generating " + numSeq.Value + " sequence(s) :\n";
                for (int i = 0; i < sequences.Length; i++)
                {
                    for (int j = 0; j < sequences[i].Length; j++)
                    {
                        resultRichTextBox.Text += emissionsSymbols.getStr(sequences[i][j]);
                        if (j != (sequences[i].Length - 1))
                            resultRichTextBox.Text += ' ';
                    }
                    resultRichTextBox.Text += '\n';
                }

                tabControl1.SelectedTab = resultTab;
            }
        }

        private void evaluationStart_Click(object sender, EventArgs e)
        {
            if (emissionsSymbols == null || observationsList == null)
            {
                MessageBox.Show("Error! You need to first create the HMM and load some observations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (evaluateCheckBox.Checked || viterbiCheckbox.Checked)
                {
                    int i = 0;
                    foreach (var item in observationsList)
                    {
                        hmm.InitializeObservation(item.ToArray());
                        var POGivenLambda = hmm.Evaluate(item.ToArray(), backwardButton.Checked);
                        resultRichTextBox.Text += ">>> Observation " + i + " : <<<\n";

                        if (evaluateCheckBox.Checked)
                        {
                            resultRichTextBox.Text += "Forward/Backward result: " + POGivenLambda + "\n\n";
                        }
                        if (viterbiCheckbox.Checked)
                        {
                            double probability;
                            int[] path = hmm.MostLikelyPath(item.ToArray(), out probability);

                            resultRichTextBox.Text += "Viterbi result:\nP(path)=" + (probability / POGivenLambda) + "\npath:\n";
                            for (int j = 0; j < path.Length; j++)
                            {
                                resultRichTextBox.Text += emissionsSymbols.getStr(item[j]) + "\t" + stateSymbols.getStr(path[j]) + "\n";
                            }
                            resultRichTextBox.Text += "\n\n\n";
                        }
                        i++;
                    }

                    tabControl1.SelectedTab = resultTab;
                }
                else
                {
                    MessageBox.Show("You need to select what to do first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            if (emissionsSymbols == null || observationsList == null)
            {
                MessageBox.Show("Error! You need to first create the HMM and load some observations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                resultRichTextBox.Text += "Baum-Welch result:\n";
                int[][] arrays = observationsList.Select(a => a.ToArray()).ToArray();
                hmm.Learn(arrays);

                resultRichTextBox.Text += "Initial probabilities\n";
                for (int i = 0; i < hmm.Probabilities.Length; i++)
                {
                    resultRichTextBox.Text += stateSymbols.getStr(i) + "\t" + hmm.Probabilities[i] + "\n";
                }

                resultRichTextBox.Text += "\nTransmission matrix\n";
                foreach (var item in hmm.Transitions)
                {
                    int i = -1, j = -1;
                    hmm.Transitions.SeparateCombinedKeys(item.Key, ref i, ref j);
                    resultRichTextBox.Text += stateSymbols.getStr(i) + "\t" + stateSymbols.getStr(j) + "\t" + item.Value + "\n";
                }

                resultRichTextBox.Text += "\nEmissions matrix\n";
                foreach (var item in hmm.Emissions)
                {
                    int i = -1, j = -1;
                    hmm.Emissions.SeparateCombinedKeys(item.Key, ref i, ref j);
                    resultRichTextBox.Text += stateSymbols.getStr(i) + "\t" + emissionsSymbols.getStr(j) + "\t" + item.Value + "\n";
                }
                resultRichTextBox.Text += "\n\n";

                tabControl1.SelectedTab = resultTab;
            }
        }

        #endregion

    }
}
