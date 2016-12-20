using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataContainer;
using System.Threading;
using System.ComponentModel;

namespace CarRentalService
{
    public partial class CalcFare : Form
    {

     
        public CalcFare()
        {
            InitializeComponent();   //constructor : google.       
           
        }

        public string CType,CName;
        public int Kms, Hrs, ExtraHrs, ExtraKms;
        public int N_Economy = 30, N_Executive = 20, N_Suv = 10;
        //when calculate fare is clicked 
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            Class1 C = Class1.Instance();
            List<Booking> L = new List<Booking>();
            L = C.GetBList();

            comboBox4.Items.Clear();

            foreach (var Item in L)
            {
                int check = 0;
                for (int i = 0; i < comboBox4.Items.Count; i++)
                {

                    if (Item.CustomerName == comboBox4.Items[i].ToString()) 
                    {
                        check = 1;
                        break;
                    }

                }

                if (check != 1)
                {
                    //ToolStripItem subItem = new ToolStripMenuItem(Item.CustomerName);

                    //toolStripMenuItem2.DropDownItems.Add(subItem);


                    comboBox4.Items.Add(Item.CustomerName);
                }
            }


        }

        // when all rentals is clicked 
        private void dailyRentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            Class1 C = Class1.Instance();
            List<RentalDetails> L = new List<RentalDetails>();
            L = C.GetList();
            var item = new BindingList<RentalDetails>(L);

            dataGridView1.DataSource = item;
          
        }


        
        // when customer details sub item clicked 
        private void toolStripMenuItem2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            dataGridView2.Rows.Clear();       
                    string s=   e.ClickedItem.Text;
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = true;

            dataGridView2.ColumnCount = 5;
            dataGridView2.Columns[0].Name = "Car type";
            dataGridView2.Columns[1].Name = "Distance";
            dataGridView2.Columns[2].Name = "Duration";
            dataGridView2.Columns[3].Name = "Gross fare";
            dataGridView2.Columns[4].Name = "Net fare";


            Class1 C = Class1.Instance();

            List<DataContainer.RentalDetails> L = new List<RentalDetails>();
            L = C.GetList();

            foreach(var Item in L)
            {
                if (Item.CustomerName == s)
                {
                    string[] row = new string[] { Item.CarType, Convert.ToString(Item.Distance), Convert.ToString(Item.Duration), Convert.ToString(Item.GrossFare), Convert.ToString(Item.NetFare) };
                    dataGridView2.Rows.Add(row);


                }

            }



        }


        //  when customer details is clicked !

        private void toolStripMenuItem2_MouseEnter(object sender, EventArgs e)
        {
            Class1 C = Class1.Instance();

            List<DataContainer.RentalDetails> L = new List<RentalDetails>();
            L = C.GetList();

           toolStripMenuItem2.DropDownItems.Clear();




            //for (int i = 0; i < toolStripMenuItem2.DropDownItems.Count; i++)
            //{


            //    if (Item.CustomerName == toolStripMenuItem2.DropDownItems[i].Text)
            //    {

            //        check = 1;
            //        break;
            //    }


                foreach (var Item in L)
            {
                int check = 0;
                foreach (ToolStripItem box in toolStripMenuItem2.DropDownItems)
                {

                    if (Item.CustomerName == box.Text)
                    {
                        check = 1;
                        break;
                    }

                }

                if (check != 1)
                {
                    ToolStripItem subItem = new ToolStripMenuItem(Item.CustomerName);

                    toolStripMenuItem2.DropDownItems.Add(subItem);
                }
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Populate();
        }

        private void rentACarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;

        }

        void Populate()
        {
            if (Convert.ToString(comboBox1.SelectedItem) == "Economy")
            {
                comboBox2.Items.Add("Ford");
                comboBox2.Items.Add("Maruthi");
                comboBox2.Items.Add("Tata");
                if (Convert.ToString(comboBox2.SelectedItem) == "Ford")
                {
                    comboBox3.Items.Add("Figo");
                }
                else if (Convert.ToString(comboBox2.SelectedItem) == "Maruthi")
                {
                    comboBox3.Items.Add("Swift");
                }
                else if (Convert.ToString(comboBox2.SelectedItem) == "Tata")
                {
                    comboBox3.Items.Add("Indica");
                }
            }
            else if (Convert.ToString(comboBox1.SelectedItem) == "Executive")
            {
                comboBox2.Items.Add("Ford");
                comboBox2.Items.Add("Maruthi");
                comboBox2.Items.Add("Tata");
                if (Convert.ToString(comboBox2.SelectedItem) == "Ford")
                {
                    comboBox3.Items.Add("Aspire");
                }
                else if (Convert.ToString(comboBox2.SelectedItem) == "Maruthi")
                {
                    comboBox3.Items.Add("Ciaz");
                }
                else if (Convert.ToString(comboBox2.SelectedItem) == "Tata")
                {
                    comboBox3.Items.Add("Zest");
                }

            }
            else if (Convert.ToString(comboBox1.SelectedItem) == "Suv")
            {

                comboBox2.Items.Add("Ford");
                comboBox2.Items.Add("Maruthi");
                comboBox2.Items.Add("Tata");
                if (Convert.ToString(comboBox2.SelectedItem) == "Ford")
                {
                    comboBox3.Items.Add("Endevour");
                }
                else if (Convert.ToString(comboBox2.SelectedItem) == "Maruthi")
                {
                    comboBox3.Items.Add("Grand Vitara");
                }
                else if (Convert.ToString(comboBox2.SelectedItem) == "Tata")
                {
                    comboBox3.Items.Add("Safari Storme");
                }
            }
        }

        public int count = 1;
        // after book is pressed! 
        private void button4_Click(object sender, EventArgs e)
        {
           
            panel6.Visible = false;

            if (textBox4.Text != "")
            {
                label13.Visible = true;
                label13.Text = "Your car is booked! ";
                button4.Visible = false;
            }


            Booking B = new Booking();
            Class1 C = Class1.Instance();
            B.CarType = type;
            B.CustomerName = textBox4.Text;
            B.CarMake = comboBox2.Text;
            B.CarModel = comboBox3.Text;
            B.key = count;
            C.SetBList(B);
            count++;

        }

        public string type;
        //after rent a car is pressed ! 
        private void button3_Click(object sender, EventArgs e)
        {
            //panel4.Visible = false;
           panel5.Visible = false;
            button4.Visible = true;
            label13.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
            type = Convert.ToString(comboBox1.SelectedItem);

            if(type == "Economy")
            {
                if (N_Economy > 0)
                {
                    panel5.Visible = true;
                }else
                {
                    panel6.Visible = true;
                }
            }
            if (type == "Executive")
            {
                if (N_Executive > 0)
                {
                    panel5.Visible = true;
                }
                else
                {
                    panel6.Visible = true;
                }
            }
            if (type == "Suv")
            {
                if (N_Suv > 0)
                {
                    panel5.Visible = true;
                }
                else
                {
                    panel6.Visible = true;
                }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Populate();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class1 C = Class1.Instance();
            List<Booking> L = new List<Booking>();
            L = C.GetBList();

            string s = comboBox4.SelectedItem.ToString();

            foreach (var item in L)
            {
                if (item.CustomerName == s)
                {
                    CarType.Items.Add(item.key);
                }

            }
        }
        //when booked cars is pressed 
        private void bookedCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
            panel3.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            Class1 C = Class1.Instance();
            List<Booking> B = new List<Booking>();
            B = C.GetBList();
            var list = new BindingList<Booking>(B);

            if (C.GetBList().Count > 0)
            {
                panel1.Visible = false;
                panel8.Visible = false;
                panel7.Visible = true;

                dataGridView3.DataSource = list;
            }
            else
            {
                panel7.Visible = false;
                panel8.Visible = true;
            }
        }



        // book another car
        private void button5_Click(object sender, EventArgs e)
        {

            if(type== "Economy")
            {
                N_Economy--;
            }
          else if (type == "Executive")
            {
                N_Executive--;
            }
            else if(type == "Suv")
            {
                N_Suv--;
            }

            panel4.Visible = true;
            panel5.Visible = false;
            button4.Visible = true;
            label13.Visible = false;
            panel8.Visible = false;
            Populate();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel5.Visible = false;
                    
            panel6.Visible = false;

        }

        double FareTime = 0, FareKms = 0,BasicFare=1450, GrossFare = 0, NetFare = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            comboBox1.Items.Add("Economy");
            comboBox1.Items.Add("Executive");
            comboBox1.Items.Add("Suv");

            numericUpDown1.Minimum = 8;
           
         numericUpDown3.Maximum = 100000;

        }

        // Calculate fare
        public void button1_Click(object sender, EventArgs e)
        {

            CType = Convert.ToString(CarType.SelectedItem);
            CName = comboBox4.SelectedItem.ToString();
             Kms = Convert.ToInt32(numericUpDown3.Value);
             Hrs = Convert.ToInt32(numericUpDown1.Value);
             ExtraHrs = Hrs - 8;           
             ExtraKms = Kms - 80;
            BasicFare = 1450;
            if (CType == "Economy")
               {
                if(ExtraHrs>0)
               FareTime = BasicFare + ExtraHrs * 100;

                if (ExtraKms>0)
                {
                   FareKms = BasicFare + ExtraKms * 8;
                }

                if (FareTime > FareKms )
                 BasicFare = FareTime;
                 else if(FareTime < FareKms)
                 BasicFare = FareKms;

                 GrossFare = BasicFare - 250;

                NetFare = GrossFare + GrossFare * 0.0412;
            }

           else if (CType =="Executive")
            {
               BasicFare =  BasicFare * 1.5;
                if (ExtraHrs > 0)
                {

                    FareTime = BasicFare + (ExtraHrs * 200);

                }
                if (ExtraKms > 0)
                {

                    FareKms = BasicFare +( ExtraKms * (8* 1.5)); 

                }
                if (FareTime > FareKms)
                    BasicFare = FareTime;
                else if (FareTime < FareKms)
                    BasicFare = FareKms;

                GrossFare =BasicFare -  (250*2 + BasicFare * 0.10);

                NetFare = GrossFare + GrossFare * 0.0412;
            }

            else
            {
                BasicFare = BasicFare + BasicFare * 3;

                if (ExtraHrs > 0)
                {

                    FareTime = (BasicFare + ExtraHrs * 100) * 2;

                }

                if (ExtraKms > 0)
                {


                    FareKms = (BasicFare + ExtraKms * 100) * 1.75;

                }
                if (FareTime > FareKms)
                    BasicFare = FareTime;
                else if (FareTime < FareKms)
                    BasicFare = FareKms;

                GrossFare = BasicFare- ( 250 * 2 + BasicFare * 0.15);

                NetFare = GrossFare + GrossFare * 0.0412;
            }


            textBox2.Text = Convert.ToString(NetFare);

        }

        //submit button

        private void button2_Click(object sender, EventArgs e)
        {


            RentalDetails R = new RentalDetails();

            R.CustomerName = CName;
            R.CarType = CType;
            R.Distance = Kms;
            R.Duration = Hrs;
            R.GrossFare = GrossFare;
            R.NetFare = NetFare;
            R.key = Convert.ToInt32(CarType.SelectedItem);
            Class1 C = Class1.Instance();

            C.SetList(R);

            //deleting corresding key entry in BDetails
            List<Booking> B = new List<Booking>();

            B = C.GetBList();

            foreach (var item in B)
            {
                if(item.key == Convert.ToInt32(CarType.SelectedItem))
                {
                    C.GetBList().Remove(item);
                    break;
                }
            }
            


          
        }
    }
}
