namespace CalculadoraIphone
{
    public partial class MainPage : ContentPage
    {
        double n1, n2;


        public MainPage()
        {
            InitializeComponent();
        }

        private void btnBorrarTodo_Clicked(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            lblOperación.Text = "";
        }

        private void btnBorrarDigito_Clicked(object sender, EventArgs e)
        {
            if (lblResultado.Text.Length > 1)
            {
                lblResultado.Text = lblResultado.Text.Remove(lblResultado.Text.Length - 1);
            }
            else
            {
                lblResultado.Text = "0";
            }
        }

        //Operaciones
        private void BotonNumericoClickeado(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            string numeroPresionado = boton.Text;

            if (lblResultado.Text == "0")
            {
                lblResultado.Text = numeroPresionado;
            }
            else
            {
                lblResultado.Text = lblResultado.Text + numeroPresionado;
            }
        }


        private void btnIgual_Clicked(object sender, EventArgs e)
        {
            Calcular();
        }

        private void btnComa_Clicked(object sender, EventArgs e)
        {
            lblResultado.Text = lblResultado.Text + ",";
        }

        private void btnCambiarSigno_Clicked(object sender, EventArgs e)
        {

        }

        private void Calcular()
        {
            if (lblResultado.Text.Contains("+"))
            {
                n1 = Convert.ToDouble(lblResultado.Text.Split('+')[0].Trim());
                n2 = Convert.ToDouble(lblResultado.Text.Split('+')[1].Trim());

                lblOperación.Text = lblResultado.Text;
                lblResultado.Text = Convert.ToString(n1 + n2);
            }
            else if (lblResultado.Text.Contains("-"))
            {
                n1 = Convert.ToDouble(lblResultado.Text.Split('-')[0].Trim());
                n2 = Convert.ToDouble(lblResultado.Text.Split('-')[1].Trim());

                lblOperación.Text = lblResultado.Text;
                lblResultado.Text = Convert.ToString(n1 - n2);
            }
            else if (lblResultado.Text.Contains("x"))
            {
                n1 = Convert.ToDouble(lblResultado.Text.Split('x')[0].Trim());
                n2 = Convert.ToDouble(lblResultado.Text.Split('x')[1].Trim());

                lblOperación.Text = lblResultado.Text;
                lblResultado.Text = Convert.ToString(n1 * n2);
            }
            else if (lblResultado.Text.Contains("÷"))
            {
                n1 = Convert.ToDouble(lblResultado.Text.Split('÷')[0].Trim());
                n2 = Convert.ToDouble(lblResultado.Text.Split('÷')[1].Trim());

                if (n2 == 0)
                {
                    lblOperación.Text = lblResultado.Text;
                    lblResultado.Text = "Math ERROR";
                }
                else
                {
                    lblOperación.Text = lblResultado.Text;
                    lblResultado.Text = Convert.ToString(n1 / n2);
                }
            }
            else if (lblResultado.Text.Contains("%"))
            {
                if (lblResultado.Text.Split('%').Length == 2)
                {
                    n1 = Convert.ToDouble(lblResultado.Text.Split('%')[0].Trim());
                    n2 = Convert.ToDouble(lblResultado.Text.Split('%')[1].Trim());

                    lblOperación.Text = lblResultado.Text;
                    lblResultado.Text = Convert.ToString((n1 * n2) / 100);
                }
                else
                {
                    n1 = Convert.ToDouble(lblResultado.Text.Split('%')[0].Trim());
                    lblOperación.Text = lblResultado.Text;
                    lblResultado.Text = Convert.ToString(n1 / 100);
                }
            }
        }

        private void OperadorClickeado(object sender, EventArgs e)
        {
            if(lblResultado.Text.Contains("+") && !lblResultado.Text.EndsWith("+") || lblResultado.Text.Contains("-") && !lblResultado.Text.EndsWith("-") || lblResultado.Text.Contains("x") && !lblResultado.Text.EndsWith("x") || lblResultado.Text.Contains("÷") && !lblResultado.Text.EndsWith("÷") || lblResultado.Text.Contains("%") && !lblResultado.Text.EndsWith("%"))
            {
                Calcular();   
            }

            Button boton = (Button)sender;
            string operadorPresionado = boton.Text;
            
            if (lblResultado.Text.EndsWith("+") || lblResultado.Text.EndsWith("-") || lblResultado.Text.EndsWith("x") || lblResultado.Text.EndsWith("÷") || lblResultado.Text.EndsWith("%"))
            {
                lblResultado.Text = lblResultado.Text.Remove(lblResultado.Text.Length - 1) + operadorPresionado;
            }
            else
            {
                lblResultado.Text = lblResultado.Text + operadorPresionado;
            }
        }
    }
}
