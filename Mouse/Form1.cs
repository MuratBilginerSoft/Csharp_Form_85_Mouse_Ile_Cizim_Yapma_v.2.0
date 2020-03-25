using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mouse
{
    public partial class Form1 : Form
    {
        #region tanımlamalar

        bool ciz; // true yada false değerlerini alabilir

        int baslaX, baslaY; // mouse un o anki form üzerinde bulunduğu konumun koordinatlarını tutacaklar.

        int kalınlık=3;

        ColorDialog renkseç = new ColorDialog(); // renk seçimini yapmak için gerekli nesnemiz

        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // mouse un herhangi bir tuşuna basıldığı anda çalışacak kodlar.
            // mouseDown un anlamıda bu zaten tıklandığı andaki işlemler.

            ciz = true; // çizim ifadesi değerini true yaptık. 

            baslaX = e.X; /* MouseDown yani farenin bir tuşuna tıklandığı anda 
                           * mouse un yaptığı işlemler e değişkeninde saklanır.
                           * bizde buradan bu özelliğinden yararlanarak e.X ile
                           * x koordinatını almış olduk. ve baslaX değişkenine 
                           * atadık*/
            baslaY = e.Y; // yukarıdaki işlemin aynısını bir de y koordinatı için yaptık.
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            /* MouseMove ise mouse basılı iken mouse u taşıma işlemi 
            * yaparken yapılacak işlemleri ifade eder. */

            Graphics g = this.CreateGraphics();  /* çizimi yapabilmek için graphic 
                                                  * türünde bir g değişkeni oluşturduk. 
                                                  * ve çizimi nerde yapacaksa biz 
                                                  * form üzerinde yapacağımız için 
                                                  * this.CreateGraphics dedik. */

            /* Burada bir kaç bir şeyi anlatmalıyım. Şimdi graphics nesnesi ile
             * kullanabileceğimiz pek çok çizim aracı ve çizim şekli var. Ve bu çizim
             * şekilleri kendi özelliklerine göre bir takım parametreler alırlar.
             * Mesela biz birazdan kullanacağımız Drawline yani düz çizgi şeklinden 
             * bahsedecek olursak. Drawline 3 tane parametre alır bir çizim yapacak 
             * aracı 2 bir başlangıç noktası koordinatlarını ve son olarakta bitiş noktası 
             * koordinatlarını parametre olarak alır. şimdi birazdan kullanacağımız bu 
             * parametreleri oluşturacağız*/
            
            Pen p = new Pen(renkseç.Color, kalınlık); /* kalem aracını p değişkeninde tanımladık 
                                            * ve kalemi oluşturmasını sağladık. gördüğünüz 
                                            * gibi kalem 2 parametre almakta birincisi çizim
                                            * yaparkenki rengi , 2.side kalınlığını belirtecek olan
                                            * bir sayı değeri alır. */

            Point point1 = new Point(baslaX, baslaY); /* az önce bahsettiğimiz başlangıç
                                                       * noktalasını oluşturduk. */

            Point point2 = new Point(e.X, e.Y); /* buradada bitiş noktasını tanımladık */

            if (ciz == true) //ciz ifadesi true ise çalışacak kodlar
            {
                g.DrawLine(p, point1, point2); /* az önce bahsettiğim gibi g.DrawLine 
                                                * ile düz çizgi çizileceğini bildirdik. ve
                                                * parametrelerimizi girdik.*/

                baslaX = e.X; // mouse un durduğu son noktayıda yeni başlangıc değeri olarak atadık */
                baslaY = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            /* MouseUp ise basılı mouse tuşunun bırakıldığı anı ifade eder */

            ciz = false; /* ciz ifadesi false oldu. yani mouse bırakıldığı anda çizim 
                          * çizim işlemide bitecek demek oluyor. */
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://muratbilginerncfkr.blogspot.com/"); 
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
           
            renkseç.ShowDialog();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kalınlık = int.Parse(comboBox1.SelectedItem.ToString());
        }
    }
}
