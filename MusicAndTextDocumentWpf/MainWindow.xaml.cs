using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.IO;

namespace MusicAndTextDocumentWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

           
            var threadMusic = new Thread(PlayMusic);
            threadMusic.IsBackground = true;//Фоновый поток
            threadMusic.Start();
            
        }
        
        private   void PlayMusic()
        {
            
            var player = new MediaPlayer();
            player.Open(new Uri("beethoven.mp3", UriKind.RelativeOrAbsolute));
            while (true) { 
            player.Play(); }
           
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            var dataRichTextBox = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            using (var stream = new StreamWriter(nameDocument.Text + ".txt"))
            {
                stream.WriteLine(dataRichTextBox);
                stream.Close();
            }
        }


     
    }
}
