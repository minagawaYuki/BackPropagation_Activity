using Backprop;


namespace Neural_Network_Activity
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(4, 500, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nn == null)
            {
                return;
            }
            // Training data for a 4-input AND gate
            double[,] inputs = {
                { 0, 0, 0, 0 }, { 0, 0, 0, 1 }, { 0, 0, 1, 0 }, { 0, 0, 1, 1 },
                { 0, 1, 0, 0 }, { 0, 1, 0, 1 }, { 0, 1, 1, 0 }, { 0, 1, 1, 1 },
                { 1, 0, 0, 0 }, { 1, 0, 0, 1 }, { 1, 0, 1, 0 }, { 1, 0, 1, 1 },
                { 1, 1, 0, 0 }, { 1, 1, 0, 1 }, { 1, 1, 1, 0 }, { 1, 1, 1, 1 }
            };

            double[] outputs = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

            for (int epoch = 0; epoch < 100; epoch++)
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        nn.setInputs(j, inputs[i, j]);
                    }
                    nn.setDesiredOutput(0, outputs[i]);
                    nn.learn();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nn == null || MissingInput())
            {
                return;
            }
            // Test the network
            nn.setInputs(0, Convert.ToDouble(textBox1.Text));
            nn.setInputs(1, Convert.ToDouble(textBox2.Text));
            nn.setInputs(2, Convert.ToDouble(textBox4.Text));
            nn.setInputs(3, Convert.ToDouble(textBox5.Text));
            nn.run();
            textBox3.Text = "" + nn.getOuputData(0);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private bool MissingInput()
        {
            return textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "";
        }
    }
}
