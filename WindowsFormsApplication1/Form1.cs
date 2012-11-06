using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuecatDecoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int step5 = 0;
        public int step15 = 0;
        // Handle the KeyDown event to determine the type of character entered into the control. 
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //this.textBox1.Text = "test2";
            // Determine whether the keystroke is a enter 
            if (e.KeyCode == Keys.Enter)
            {
                //this.textBox1.Text = "test1";
                
                string stringreferencechars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+-";
                int[] asciivalues = { 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 65, 66, 67, 68, 69, 70, 71, 72, 73 ,74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 43, 45};
                //string[] encodedinput1 = this.textBox1.Text.Substring(1,this.textBox1.Text.Length-1).Split('.');
                //string[] encodedinput = encodedinput1[2].Select(c => c.ToString()).ToArray();
                string[] encodedinput = this.textBox1.Text.Select(c => c.ToString()).ToArray();
                string tempvar = "";
                int current = 0;
                string curchar = "";
                while (current < encodedinput.Length)
                {
                    //for (int current = 0; current < encodedinput.Length; current++) {
                    try
                    {       //yes, you numskulls, I know this is horrible code. deal with it. I'm following the guide at
                            //http://www.rkgage.net/bobby/cuecat/decode2.htm step by step.
                        curchar = encodedinput[current]; //get the first character
                        current++;
                        int step1 = stringreferencechars.IndexOf(curchar) + 1; //get the first character's position
                        int step2 = step1 - 1; //subtract 1
                        int step3 = step2 << 2; //shift to the left two places
                        curchar = encodedinput[current]; //get the second character
                        current++;
                        int step4 = stringreferencechars.IndexOf(curchar) + 1; //get the second character's position
                        step5 = step4 - 1; //subtract 1
                        int step6 = step5 >> 4; //shift right 4 places
                        int step7 = step3 | step6; //binary or steps 3 and 6
                        int step8 = step7 ^ 3; //binary xor, step 7 and the int 3.
                        int step9 = step8 + 64; //add 64
                        int step10 = (step9 > 128 ? step9 - 128 : step9); //if step 9 > 128, then subtract 128.
                        int step11 = Array.IndexOf(asciivalues, step10); //convert to a character
                        string stepper = stringreferencechars.Substring(step11, 1);
                        tempvar += stepper;
                        //tempvar += stepper;
                        //tempvar = Convert.ToString(step1) + "," + Convert.ToString(step2) + "," + Convert.ToString(step3) + "," + Convert.ToString(step4) + "," + Convert.ToString(step5) + "," + Convert.ToString(step6) + "," + Convert.ToString(step7) + "," + Convert.ToString(step8) + "," + Convert.ToString(step9) + "," + Convert.ToString(step10) + "," + Convert.ToString(step11);
                        //this.textBox1.Text = tempvar;
                    }
                    catch {   }
                    //step12: end if there's no other character
                    //this.textBox1.Text = tempvar;
                    //return;
                    try
                    {
                        int step13 = step5 << 4; //take step5 and shift left 4 places
                        curchar = encodedinput[current]; //get the third character
                        current++;
                        int step14 = stringreferencechars.IndexOf(curchar) + 1; //get the third character's position
                        step15 = step14 - 1; //subtract 1
                        int step16 = step15 >> 2; //shift right 2
                        int step17 = step13 | step16; //bitwise or of steps 13 and 16
                        int step18 = step17 ^ 3; //xor step17 with 3
                        int step19 = step18 + 64; //add 64
                        int step20 = (step19 > 128 ? step19 - 128 : step19); //if more than 128, subtract 128.
                        int step21 = Array.IndexOf(asciivalues, step20); //convert to a character
                        string stepper = stringreferencechars.Substring(step21, 1);
                        tempvar += stepper;
                        //tempvar = Convert.ToString(step5) + "," + Convert.ToString(step13) + "," + Convert.ToString(step14) + "," + Convert.ToString(step15) + "," + Convert.ToString(step16) + "," + Convert.ToString(step17) + "," + Convert.ToString(step18) + "," + Convert.ToString(step19);
                        //this.textBox1.Text = tempvar;
                    }
                    catch {  }
                    //step 22: end if there's no other character.
                    //return;
                    try
                    {
                        int step23 = 12 << 6;
                        step23 = (step23 > 256 ? 0 : step23);
                        curchar = encodedinput[current]; //get the fourth character
                        current++;
                        int step24 = stringreferencechars.IndexOf(curchar) + 1; //get the fourth character's position
                        int step25 = step24 - 1; //subtract 1
                        int step26 = step23 | step25; //step 23 bitwise or step 25
                        int step27 = step26 ^ 3; //step 26 xor 3
                        int step28 = step27 + 64; //add 64
                        char step29 = (char)step28;
                        int step30 = Array.IndexOf(asciivalues, step29); //convert to a character
                        //tempvar = Convert.ToString(step15) + "," + Convert.ToString(step23) + "," + Convert.ToString(step24) + "," + Convert.ToString(step25) + "," + Convert.ToString(step26) + "," + Convert.ToString(step27) + "," + Convert.ToString(step28) + "," + Convert.ToString(step29);
                        //this.textBox1.Text = tempvar;
                        //return;
                        string stepper = stringreferencechars.Substring(step30, 1);
                        tempvar += stepper;
                        this.textBox1.Text = tempvar;
                    }
                    catch { }
                    //this.textBox1.Text = "test";
                }
                //this.textBox1.Text = tempvar;
                
            }
                 
        }
    }
}