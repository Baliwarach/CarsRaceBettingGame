using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CarsRaceBettingGame;
using MySql.Data.MySqlClient;

namespace CarsRaceBettingGame
{
    public partial class Form1 : Form
    {
        List<int> johnlisting = new List<int>();
        List<int> michallisting = new List<int>();
        List<int> jameslisting = new List<int>();

        public Form1()
        {
            InitializeComponent();
            johnlisting.Add(45);
            michallisting.Add(45);
            jameslisting.Add(45);
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Accountmanitain h = new Accountmanitain();
            //h.otherupdate();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    label1.Text = string.Empty;
                    label2.Text = string.Empty;
                    label3.Text = string.Empty;
                }
                else if(ctrl.GetType() == typeof(RadioButton)){
                    ((RadioButton)(ctrl)).Checked = false;

                }
                else if (ctrl.GetType() == typeof(ComboBox))
                {
                    comboBox1.Text = string.Empty;
                    comboBox2.Text = string.Empty;
                   
                }
                // method to remove all amount from john list except the first amount which is 45 (max amount)
                if (johnlisting.Count>1)
                {
                    johnlisting.RemoveRange(1, johnlisting.Count - 1);
                    //MessageBox.Show("first one johnlisting "+johnlisting[0]);

                }
                //  method to remove all amount from michal list amount except the first amount which is 45 (max amount)
                if (michallisting.Count > 1)
                {
                    michallisting.RemoveRange(1, michallisting.Count - 1);
                    //MessageBox.Show("first one michallisting " + michallisting[0]);

                }
                //method to remove all amount from james list amount except the first amount which is 45(max amount)
                if (jameslisting.Count > 1)
                {
                    jameslisting.RemoveRange(1, jameslisting.Count - 1);
                    //MessageBox.Show("first one jameslisting " + jameslisting[0]);

                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label1.Text = "John Bets an Amount $ " + this.comboBox1.SelectedItem.ToString() + " on Bike " + this.comboBox2.SelectedItem.ToString();

            }
            else if (radioButton2.Checked)
            {
                label2.Text = "Michal Bets an Amount $ " + this.comboBox1.SelectedItem.ToString() + " on Bike " + this.comboBox2.SelectedItem.ToString();

            }
            else if (radioButton3.Checked)
            {
                label3.Text = "James Bets an Amount $ " + this.comboBox1.SelectedItem.ToString() + " on Bike " + this.comboBox2.SelectedItem.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text == string.Empty)
            {
                MessageBox.Show("Please select the player, Amount and Betting Bike");
                return;

            }
            else if (label2.Text == string.Empty)
            {
                MessageBox.Show("Please select the player, Amount and Betting Bike");
                return;
            }
            else if (label3.Text == string.Empty)
            {
                MessageBox.Show("Please select the player, Amount and Betting Bike");
                return;

            }
            timer1.Enabled = true;
            /*//Random Number generation
            Random randomnumber = new Random();
            int r = randomnumber.Next(1,5);
            MessageBox.Show("Bike "+ r+ " \n wins the race");
            
            string[] john = new string[10];
            string johnstring = label1.Text;
            john = johnstring.Split(' ');
           

            //this code splits the text and store in jack string array
            string[] michal= new string[10];
            string michalstr = label2.Text;
            michal = michalstr.Split(' ');
            //this code splits the text and store in Tom string array
            string[] james = new string[10];
            string jamesstr = label3.Text;
            james = jamesstr.Split(' ');
            int max = 45;
            Accountmanitain h = new Accountmanitain();
            if (r == Convert.ToInt32(john[8]))
            {
                MessageBox.Show("Congrats! John Won the Bet ");
                int jscore = Convert.ToInt32(michal[5]) + Convert.ToInt32(james[5]);
                int jscore1 = Convert.ToInt32(john[5]) + Convert.ToInt32(michal[5]) + Convert.ToInt32(james[5]);
                MessageBox.Show("You are awarded with" + jscore);
                h.JohnupdateData(jscore1);
                int mscore = Convert.ToInt32(h.Selectdata(2));
                int mscore1 = mscore - Convert.ToInt32(michal[5]);
                h.michalupdateData(mscore1);
                int jascore = Convert.ToInt32(h.Selectdata(3));
                int jascore1 = jascore - Convert.ToInt32(james[5]);
                h.michalupdateData(jascore1);
                radioButton2.Enabled = false;
                label2.Text = "You are busted";
                radioButton3.Enabled = false;
                label3.Text = "You are busted";
            }
            else if(Convert.ToInt32(h.Selectdata(1)) == 0)
            {
                radioButton1.Enabled = false;
                label1.Text = "You are busted";

            }
           
            // code to check whether michal is a winner
            else if (r == Convert.ToInt32(michal[8]))
            {
                MessageBox.Show("Congrats! Michal Won the Bet ");
                int mscore = Convert.ToInt32(john[5]) + Convert.ToInt32(james[5]);
                int mscore1 = Convert.ToInt32(john[5]) + Convert.ToInt32(michal[5]) + Convert.ToInt32(james[5]);
                MessageBox.Show("You are awarded with" + mscore);
                h.michalupdateData(mscore1);
                int johnscore = Convert.ToInt32(h.Selectdata(1));
                int johnscore1 = johnscore - Convert.ToInt32(john[5]);
                h.JohnupdateData(johnscore1);
                int jascore = Convert.ToInt32(h.Selectdata(3));
                int jascore1 = jascore - Convert.ToInt32(james[5]);
                h.jamesupdateData(jascore1);
                radioButton1.Enabled = false;
                label1.Text = "You are busted";
                radioButton3.Enabled = false;
                label3.Text = "You are busted";






            }
            else if (Convert.ToInt32(h.Selectdata(2)) == 0 )
            {


                radioButton2.Enabled = false;
                label2.Text = "You are busted";

            }
            //code to check whether james is a winner
            else if (r == Convert.ToInt32(james[8]))
            {
                MessageBox.Show("Congrats! James Won the Bet ");
                int jimscore = Convert.ToInt32(john[5]) + Convert.ToInt32(michal[5]);
                int jimscore1 = Convert.ToInt32(john[5]) + Convert.ToInt32(michal[5]) + Convert.ToInt32(james[5]);
                MessageBox.Show("You are awarded with" + jimscore);
                h.jamesupdateData(jimscore1);
                int johnscore = Convert.ToInt32(h.Selectdata(1));
                int johnscore1 = johnscore - Convert.ToInt32(john[5]);
                h.JohnupdateData(johnscore1);
                int mscore = Convert.ToInt32(h.Selectdata(2));
                int mscore1 = mscore - Convert.ToInt32(michal[5]);
                h.michalupdateData(mscore1);
                radioButton1.Enabled = false;
                label1.Text = "You are busted";
                radioButton2.Enabled = false;
                label2.Text = "You are busted";






            }
            else if (Convert.ToInt32(h.Selectdata(3)) == 0 )
            {


                radioButton3.Enabled = false;
                label3.Text = "You are busted";

            }
            else
            {
                MessageBox.Show("Sorry the car other than your betted one wins the race");
            }*/


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((pictureBox31.Left + 5) < (this.Width - pictureBox31.Width) & pictureBox32.Left + 7 < (this.Width - pictureBox32.Width) & (pictureBox33.Left + 8) < (this.Width - pictureBox33.Width) & (pictureBox34.Left + 8) < (this.Width - pictureBox34.Width))
            {
                pictureBox31.Left += 5;
                pictureBox32.Left += 7;
                pictureBox33.Left += 8;
                pictureBox34.Left += 9;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //timer2.Enabled = true;

            // timer4.Enabled = true;
            // timer5.Enabled = true;
            if (label1.Text == string.Empty)
            {
                MessageBox.Show("Please select the player, Amount and Betting Bike");
                return;

            }
            else if (label2.Text==string.Empty)
            {
                MessageBox.Show("Please select the player, Amount and Betting Bike");
                return;
            }
            else if(label3.Text==string.Empty)
            {
                MessageBox.Show("Please select the player, Amount and Betting Bike");
                return;

            }

            Random randomnumber = new Random();
            int r = randomnumber.Next(1,5);
            MessageBox.Show("Bike "+ r+ " \n wins the race");
            
            string[] john = new string[10];
            string johnstring = label1.Text;
            john = johnstring.Split(' ');
            //timer3.Enabled=true;
           

            //this code splits the text and store in jack string array
            string[] michal= new string[10];
            string michalstr = label2.Text;
            michal = michalstr.Split(' ');
            //this code splits the text and store in Tom string array
            string[] james = new string[10];
            string jamesstr = label3.Text;
            james = jamesstr.Split(' ');
            // timer4.Enabled = true;
            int max = 45;
           
            Accountmanitain h = new Accountmanitain();
            



            if (r == Convert.ToInt32(john[8]))
            {
                MessageBox.Show("Congrats! John Won the Bet ");
                int johnscore = Convert.ToInt32(michal[5]) + Convert.ToInt32(james[5]);
                int johnscore1 = Convert.ToInt32(johnlisting.Last()) + johnscore;
                MessageBox.Show("john is  awarded with " + johnscore);
                MessageBox.Show("total John amount in your account " + johnscore1);
                //h.JohnupdateData(jscore1);
                johnlisting.Add(johnscore1);
                //code to deduct michal and james amount
                int michalreduction = Convert.ToInt32(michallisting.Last()) - Convert.ToInt32(michal[5]);
                MessageBox.Show("Amount deducted from Michal account " + michal[5]);
                MessageBox.Show("Remaining amount is john account " + michalreduction);
                michallisting.Add(michalreduction);
                int jamesreduction = Convert.ToInt32(jameslisting.Last()) - Convert.ToInt32(james[5]);
                MessageBox.Show("Amount deducted from James account " + james[5]);
                MessageBox.Show("Remaining amount is James account " + jamesreduction);
                jameslisting.Add(jamesreduction);
               
                //code to check whether james and michal amount reach 0 or not
                if (Convert.ToInt32(michallisting.Last()) <= 0)
                {
                    radioButton2.Enabled = false;
                    label2.Text = "you are busted";


                }
                if (Convert.ToInt32(jameslisting.Last()) <= 0)
                {
                    radioButton3.Enabled = false;
                    label3.Text = "You are busted";

                }
                //timer5.Enabled = true;

            }

            // code to check whether michal is a winner
            else if (r == Convert.ToInt32(michal[8]))
            {
                MessageBox.Show("Congrats! Michal Wins the Bet ");
                int mscore = Convert.ToInt32(john[5]) + Convert.ToInt32(james[5]);
                int mscore1 = mscore + Convert.ToInt32(michallisting.Last());
                MessageBox.Show("Michal is awarded with" + mscore);
                MessageBox.Show("total amount in michal account" + mscore1);
                michallisting.Add(mscore1);
                //h.michalupdateData(mscore1);
                int jamesreduction = Convert.ToInt32(jameslisting.Last()) - Convert.ToInt32(james[5]);
                MessageBox.Show("Amount deducted from James account " + james[5]);
                MessageBox.Show("Remaining amount is James account " + jamesreduction);
                jameslisting.Add(jamesreduction);
                int johnreduction = Convert.ToInt32(johnlisting.Last()) - Convert.ToInt32(john[5]);
                MessageBox.Show("Amount deducted from John account " + john[5]);
                MessageBox.Show("Remaining amount is John account " + johnreduction);
                johnlisting.Add(johnreduction);
               
                if (Convert.ToInt32(jameslisting.Last()) <= 0)
                {
                    radioButton3.Enabled = false;
                    label3.Text = "You are busted";

                }
                if (Convert.ToInt32(johnlisting.Last()) <= 0)
                {
                    radioButton1.Enabled = false;
                    label1.Text = "You are busted";

                }
                //timer5.Enabled = true;
            }
            //code to check whether james is a winner
            else if (r == Convert.ToInt32(james[8]))
            {
                MessageBox.Show("Congrats! James Won the Bet ");
                int jamesscore = Convert.ToInt32(john[5]) + Convert.ToInt32(michal[5]);
                int jamesscore1 = jamesscore + Convert.ToInt32(jameslisting.Last());
                MessageBox.Show("James is awarded with" + jamesscore);
                MessageBox.Show("Total amount in james account" + jamesscore1);
                jameslisting.Add(jamesscore1);
                int michalreduction = Convert.ToInt32(michallisting.Last()) - Convert.ToInt32(michal[5]);
                MessageBox.Show("Amount deducted from Michal account " + michal[5]);
                MessageBox.Show("Remaining amount is john account " + michalreduction);
                michallisting.Add(michalreduction);
                int johnreduction = Convert.ToInt32(johnlisting.Last()) - Convert.ToInt32(john[5]);
                MessageBox.Show("Amount deducted from John account " + john[5]);
                MessageBox.Show("Remaining amount is John account " + johnreduction);
                johnlisting.Add(johnreduction);
                
                if (Convert.ToInt32(johnlisting.Last()) <= 0)
                {
                    radioButton1.Enabled = false;
                    label1.Text = "You are busted";

                }
                if (Convert.ToInt32(michallisting.Last()) <= 0)
                {
                    radioButton2.Enabled = false;
                    label2.Text = "you are busted";


                }
                //timer5.Enabled = true;




            }
           



            }

      

       

        

      

            
        
    }
}
public class Accountmanitain
{
   
    public string Selectdata(int value)
    {
        string connection = "server=localhost;username=root;password=;database=customer3";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
        //MessageBox.Show("database connected");
        string selectquery = "SELECT Amount FROM bikebettinggame WHERE id='"+ value +"' ";
        MySqlCommand command = new MySqlCommand(selectquery,conn);
        MySqlDataReader reader = command.ExecuteReader();
        int amt=0;
        string strresult = string.Empty;
        while (reader.Read())
        {
            strresult += reader.GetString(0);
        }
        string[] strArray = strresult.Split(' ');
        //MessageBox.Show("The value is" + strArray[0]);
        return strArray[0];
        
        /*string name = "Tom";
        string updatequery = "update bettinggametable set Amount = '" + Convert.ToInt32(amount) + "' where Name ='" + name + "' ";
        MySqlCommand command = new MySqlCommand(updatequery, conn);
        MySqlDataReader myreader;
        myreader = command.ExecuteReader();
        //MessageBox.Show("Data updated successfully");
        conn.Close();*/


    }
    public void JohnupdateData(int value)
    {
        string connection = "server=localhost;username=root;password=;database=customer3";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
        //MessageBox.Show("database connected");
        string selectquery = "update bikebettinggame set Amount='"+ value +"' WHERE id='" + 1 + "' ";
        MySqlCommand command = new MySqlCommand(selectquery, conn);
        MySqlDataReader reader = command.ExecuteReader();
        //MessageBox.Show("Database updated successfully");

    }
    public void michalupdateData(int value)
    {
        string connection = "server=localhost;username=root;password=;database=customer3";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
       // MessageBox.Show("database connected");
        string selectquery = "update bikebettinggame set Amount='" + value + "' WHERE id='" + 2 + "' ";
        MySqlCommand command = new MySqlCommand(selectquery, conn);
        MySqlDataReader reader = command.ExecuteReader();
        //MessageBox.Show("Database updated successfully");

    }
    public void jamesupdateData(int value)
    {
        string connection = "server=localhost;username=root;password=;database=customer3";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
        //MessageBox.Show("database connected");
        string selectquery = "update bikebettinggame set Amount='" + value + "' WHERE id='" + 3 + "' ";
        MySqlCommand command = new MySqlCommand(selectquery, conn);
        MySqlDataReader reader = command.ExecuteReader();
        //MessageBox.Show("Database updated successfully");

    }
    public void otherupdate()//THIS FUNCTION WILL RESET ALL THE AMOUNT TO PREVIOUS ONES
    {
        string connection = "server=localhost;username=root;password=;database=customer3";
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
        //MessageBox.Show("database connected");
        string selectquery = "UPDATE bikebettinggame SET Amount='" + 45 + "'  ";
        //string selectquery1 = "UPDATE bikebettinggame set Amount='" + 45 + "' WHERE id='" + 2 + "' ";
        //string selectquery2 = "update bikebettinggame set Amount='" + 45 + "'  WHERE id='" + 3 + "' ";

        MySqlCommand command = new MySqlCommand(selectquery, conn);
        //MySqlCommand command1 = new MySqlCommand(selectquery1, conn);
        //MySqlCommand command2 = new MySqlCommand(selectquery2, conn);

        MySqlDataReader reader1 = command.ExecuteReader();
        //MySqlDataReader reader2 = command1.ExecuteReader();
        // MySqlDataReader reader3 = command2.ExecuteReader();
        //MessageBox.Show("Database updated successfully");

    }
  
    

    
}
