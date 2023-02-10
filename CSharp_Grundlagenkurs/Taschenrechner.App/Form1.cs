using Taschenrechner.Lib;

namespace Taschenrechner.App
{
    public partial class Form1 : Form
    {
        Calculator calculator;


        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Wenn im Catch-Block ein Fehler passieren sollte
                calculator.MethodeMitFehler(); //z.B. hier....
            } // Von Hierarchy 
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) //Für restliche Fehler
            {
                //... dann wird der Catchblock wichtig 
                MessageBox.Show(ex.ToString());
            }
           

        }


        //Unser Kunde bekommt jeden Fehler in rauer Form mit (Direkte Exception weitergabe) 
        private void button1_Click(object sender, EventArgs e)
        {
            int? a = int.Parse(textBox1.Text);
            //int? b = int.Parse(textBox2.Text);

            try
            {
                calculator.Division(a, null);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (DivideByZeroException ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? a = int.Parse(textBox1.Text);
            int? b = int.Parse(textBox2.Text);
            
            try
            {
                double result = calculator.Division2(a, b);
                MessageBox.Show(result.ToString());
            }
            catch(CalculatorDllException ex)
            {
                MessageBox.Show(ex.ToString());
            }            
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}