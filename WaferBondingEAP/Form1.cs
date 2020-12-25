using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaferBondingEAP
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static Socket Csocket;
        Thread thread = new Thread(GetSocket

        //Socket Csocket = socket.Accept();
        //byte[] bt = new byte[1024];
        //Csocket.BeginReceive(bt, 0, bt.Length, SocketFlags.Peek, new AsyncCallback((ar) => { }), null);
        //byte[] bytes = Encoding.Default.GetBytes("GET:MAPRD;");
        //Csocket.Send(bytes);
        );

        //delegate Socket GetSocketEventHandler();
        //static GetSocketEventHandler GetSocketEvent = new GetSocketEventHandler(GetSocket);

        private static void GetSocket()
        {
            IPAddress iPAddress = IPAddress.Parse("192.168.2.34");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 3340);
            socket.Bind(iPEndPoint);
            socket.Listen(0);
            Csocket = socket.Accept();

            byte[] bt = new byte[1024];
            Csocket.BeginReceive(bt, 0, bt.Length, SocketFlags.None, new AsyncCallback(UpdateLabel), bt);
        }

        private void UpdateRE()
        {
            //byte[] bt = new byte[1024];
            //Csocket.BeginReceive(bt, 0, bt.Length, SocketFlags.Peek, new AsyncCallback((ar) => { }), null);
            byte[] bytes = Encoding.Default.GetBytes("GET:MAPRD;");
            Csocket.Send(bytes);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thread.Start();
            //this.label1.Text = Encoding.UTF8.GetString(bt);

        }

        private static void UpdateLabel(IAsyncResult ar)
        {
            //this.Invoke(new EventHandler(delegate
            //{
            //label1.Text = (string)ar.AsyncState;

            //MessageBox.Show(Encoding.UTF8.GetString((byte[])ar.AsyncState));
            //}));
             Encoding.UTF8.GetString((byte[])ar.AsyncState);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateRE();
        }
    }
}
