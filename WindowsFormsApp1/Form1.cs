﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Image file;
        Boolean opened = false;

        void openImage()
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr==DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = file;
                opened = true;
            }
        }

        void saveImage()
        {
            if(opened)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;
                if(sfd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                {
                    string ext = Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox1.Image.Save(sfd.FileName, format);
                }
                
            }
            else
            {
                MessageBox.Show("No image Loaded,Upload image first!!");
            }
        }

        void reload()
        {
            if(!opened)
            {
                MessageBox.Show("There is no opened image,Please open image!!");
            }
            else
            {
                if(opened)
                {
                    file = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = file;
                    opened = true;
                }
            }
        }




        void filter1()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image img = pictureBox1.Image;                            
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   

                ImageAttributes ia = new ImageAttributes();                 
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{.393f, .349f, .272f+1.3f, 0, 0},
            new float[]{.769f, .686f+0.5f, .534f, 0, 0},
            new float[]{.189f+2.3f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           
                Graphics g = Graphics.FromImage(bmpInverted);   

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


              


                g.Dispose();                            
                pictureBox1.Image = bmpInverted;

            }
        }








        void filter2()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image img = pictureBox1.Image;                             
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   
                                                                        

                ImageAttributes ia = new ImageAttributes();                
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{.393f, .349f+0.5f, .272f, 0, 0},
            new float[]{.769f+0.3f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f+0.5f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           
                Graphics g = Graphics.FromImage(bmpInverted);  

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


             


                g.Dispose();                           
                pictureBox1.Image = bmpInverted;

            }
        }









        void filter3()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image img = pictureBox1.Image;                            
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   

                ImageAttributes ia = new ImageAttributes();               
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{.393f+0.3f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f+0.2f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f+0.9f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);          
                Graphics g = Graphics.FromImage(bmpInverted);  
                                                           

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


               


                g.Dispose();                            
                pictureBox1.Image = bmpInverted;

            }
        }

        void grayscale()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {
                Image img = pictureBox1.Image;                            
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   

                ImageAttributes ia = new ImageAttributes();                 
                ColorMatrix cmPicture = new ColorMatrix(new float[][]      
                {
                    new float[]{0.299f, 0.299f, 0.299f, 0, 0},
                    new float[]{0.587f, 0.587f, 0.587f, 0, 0},
                    new float[]{0.114f, 0.114f, 0.114f, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 0}
                });
                ia.SetColorMatrix(cmPicture);          
                Graphics g = Graphics.FromImage(bmpInverted);   

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


               


                g.Dispose();                            
                pictureBox1.Image = bmpInverted;
            }
        }





        void fog()
        {

            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {


                Image img = pictureBox1.Image;                            
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   

                ImageAttributes ia = new ImageAttributes();                
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
            new float[]{0, 1+0.7f, 0, 0, 0},
            new float[]{0, 0, 1+1.3f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);          
                Graphics g = Graphics.FromImage(bmpInverted);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                


                g.Dispose();                         
                pictureBox1.Image = bmpInverted;



            }
        }




        void flash()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {




                Image img = pictureBox1.Image;                             
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   

                ImageAttributes ia = new ImageAttributes();                
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.9f, 0, 0, 0, 0},
            new float[]{0, 1+1.5f, 0, 0, 0},
            new float[]{0, 0, 1+1.3f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           
                Graphics g = Graphics.FromImage(bmpInverted);   

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


               

                g.Dispose();                            
                pictureBox1.Image = bmpInverted;

            }

        }




        void Frozen()
        {

            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {


                Image img = pictureBox1.Image;                             
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);  
                                                                       

                ImageAttributes ia = new ImageAttributes();                
                ColorMatrix cmPicture = new ColorMatrix(new float[][]      
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
            new float[]{0, 1+0f, 0, 0, 0},
            new float[]{0, 0, 1+5f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);          
                Graphics g = Graphics.FromImage(bmpInverted);   
                                                           

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


                


                g.Dispose();                           
                pictureBox1.Image = bmpInverted;

            }

        }




       

        void redscale()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {

                Image img = pictureBox1.Image;                           
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   

                ImageAttributes ia = new ImageAttributes();                
                ColorMatrix cmPicture = new ColorMatrix(new float[][]      
                {
                    new float[]{.393f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);          
                Graphics g = Graphics.FromImage(bmpInverted);  

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


             


                g.Dispose();                          
                pictureBox1.Image = bmpInverted;

            }
        }



        void hue()
        {
            float changered = redbar.Value * .05f;
            float changegreen = greenbar.Value * .05f;
            float changeblue = bluebar.Value * .05f;

           
            reload();
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply changes");
            }
            else
            {



                Image img = pictureBox1.Image;                             
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);   
                                                                        

                ImageAttributes ia = new ImageAttributes();                 
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+changered, 0, 0, 0, 0},
                    new float[]{0, 1+changegreen, 0, 0, 0},
                    new float[]{0, 0, 1+changeblue, 0, 0},
                    new float[]{0, 0, 0, 1, 0},
                    new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);           
                Graphics g = Graphics.FromImage(bmpInverted);   
                                                            

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);


               


                g.Dispose();                            
                pictureBox1.Image = bmpInverted;


            }
        }


        

        private void button2_Click(object sender, EventArgs e)
        {
            reload();
            filter2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reload();
            grayscale();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reload();
            redscale();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reload();
            Frozen();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            reload();
            fog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        

        private void button9_Click(object sender, EventArgs e)
        {
            redbar.Value = 0;
            greenbar.Value = 0;
            bluebar.Value = 0;
            openImage();

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            redbar.Value = 0;
            greenbar.Value = 0;
            bluebar.Value = 0;
            reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reload();
            filter1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reload();
            filter3();
        }

        private void redbar_ValueChanged(object sender, EventArgs e)
        {
            hue();
        }

        private void greenbar_ValueChanged(object sender, EventArgs e)
        {
            hue();
        }

        private void bluebar_Scroll(object sender, EventArgs e)
        {

        }

        private void bluebar_ValueChanged(object sender, EventArgs e)
        {
            hue();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox1.Refresh();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Refresh();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            reload();
            flash();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void redbar_Scroll(object sender, EventArgs e)
        {

        }

        private void greenbar_Scroll(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
