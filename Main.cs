using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;
using System.Net;
using System.Net.Sockets;

namespace Instrument_Connect
{
    public partial class Main : Form
    {
        private InputDevice piano = null;
        private SynchronizationContext context;
        Thread _socketThread;
        
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);

        private string computerId;
        private string ipString;
        private string peerIP = "";
        private int pauseTime = 100;
        private bool offline = false;

        private string ip;
        private int port;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            context = SynchronizationContext.Current;

            try
            {
                piano = new InputDevice(0);
                piano.StartRecording();
                piano.ChannelMessageReceived += HandleChannelMessageReceived;
                //piano.SysCommonMessageReceived += HandleSysCommonMessageReceived;
                //piano.SysExMessageReceived += HandleSysExMessageReceived;
                //piano.SysRealtimeMessageReceived += HandleSysRealtimeMessageReceived;
                //piano.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);
            }
            catch
            {
                midiText.Text = "No MIDI device detected";
            }

            HandleSocket();
        }

        private void HandleSocket()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            ipString = ipAddr.ToString();
            string time = DateTime.Now.ToString("hmmss");
            computerId = ipString.Substring(6, 4) + time;

            try
            {
                clientSocket.Connect(ip, port);
                serverStream = clientSocket.GetStream();
                byte[] outStream = Encoding.ASCII.GetBytes(ipString);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
            catch
            {
                offline = true;
                offlineLabel.Visible = true;
            }

            if (!(offline))
            {
                _socketThread = new Thread(Receive);
                _socketThread.Start();
            }
        }

        private void Receive()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                byte[] inStream = new byte[1024];
                serverStream.Read(inStream, 0, 1024);

                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                string[] messages = returndata.Split('-');
                string[] sData;

                for (int h = 0; h < messages.Length; h++)
                {
                    sData = messages[h].Split(' ');
                    if (sData.Length > 1) HandleData(sData);
                }
            }
        }

        private void HandleData(string[] data)
        {
            try
            { 
                if (data[1] == peerIP)
                {
                    if (data[0].EndsWith("p")) NotePress(data[0].Replace("_p", ""), false);
                    if (data[0].EndsWith("r")) NoteRelease(data[0].Replace("_r", ""), false);
                }
            }
            catch { }
        }

        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                if (e.Message.Command.ToString() == "NoteOn") NotePress(e.Message.Data1.ToString(), true);
                if (e.Message.Command.ToString() == "NoteOff") NoteRelease(e.Message.Data1.ToString(), true);
            }, null);
        }

        public void NotePress(string note, bool m)
        {
            if (m)
            {
                if (note == "21") a1m.Image = Properties.Resources.red;
                if (note == "22") bb1m.Image = Properties.Resources.blackred;
                if (note == "23") b1m.Image = Properties.Resources.red;
                if (note == "24") c1m.Image = Properties.Resources.red;
                if (note == "25") db1m.Image = Properties.Resources.blackred;
                if (note == "26") d1m.Image = Properties.Resources.red;
                if (note == "27") eb1m.Image = Properties.Resources.blackred;
                if (note == "28") e1m.Image = Properties.Resources.red;
                if (note == "29") f1m.Image = Properties.Resources.red;
                if (note == "30") gb1m.Image = Properties.Resources.blackred;
                if (note == "31") g1m.Image = Properties.Resources.red;
                if (note == "32") ab1m.Image = Properties.Resources.blackred;
                if (note == "33") a2m.Image = Properties.Resources.red;
                if (note == "34") bb2m.Image = Properties.Resources.blackred;
                if (note == "35") b2m.Image = Properties.Resources.red;
                if (note == "36") c2m.Image = Properties.Resources.red;
                if (note == "37") db2m.Image = Properties.Resources.blackred;
                if (note == "38") d2m.Image = Properties.Resources.red;
                if (note == "39") eb2m.Image = Properties.Resources.blackred;
                if (note == "40") e2m.Image = Properties.Resources.red;
                if (note == "41") f2m.Image = Properties.Resources.red;
                if (note == "42") gb2m.Image = Properties.Resources.blackred;
                if (note == "43") g2m.Image = Properties.Resources.red;
                if (note == "44") ab2m.Image = Properties.Resources.blackred;
                if (note == "45") a3m.Image = Properties.Resources.red;
                if (note == "46") bb3m.Image = Properties.Resources.blackred;
                if (note == "47") b3m.Image = Properties.Resources.red;
                if (note == "48") c3m.Image = Properties.Resources.red;
                if (note == "49") db3m.Image = Properties.Resources.blackred;
                if (note == "50") d3m.Image = Properties.Resources.red;
                if (note == "51") eb3m.Image = Properties.Resources.blackred;
                if (note == "52") e3m.Image = Properties.Resources.red;
                if (note == "53") f3m.Image = Properties.Resources.red;
                if (note == "54") gb3m.Image = Properties.Resources.blackred;
                if (note == "55") g3m.Image = Properties.Resources.red;
                if (note == "56") ab3m.Image = Properties.Resources.blackred;
                if (note == "57") a4m.Image = Properties.Resources.red;
                if (note == "58") bb4m.Image = Properties.Resources.blackred;
                if (note == "59") b4m.Image = Properties.Resources.red;
                if (note == "60") c4m.Image = Properties.Resources.red;
                if (note == "61") db4m.Image = Properties.Resources.blackred;
                if (note == "62") d4m.Image = Properties.Resources.red;
                if (note == "63") eb4m.Image = Properties.Resources.blackred;
                if (note == "64") e4m.Image = Properties.Resources.red;
                if (note == "65") f4m.Image = Properties.Resources.red;
                if (note == "66") gb4m.Image = Properties.Resources.blackred;
                if (note == "67") g4m.Image = Properties.Resources.red;
                if (note == "68") ab4m.Image = Properties.Resources.blackred;
                if (note == "69") a5m.Image = Properties.Resources.red;
                if (note == "70") bb5m.Image = Properties.Resources.blackred;
                if (note == "71") b5m.Image = Properties.Resources.red;
                if (note == "72") c5m.Image = Properties.Resources.red;
                if (note == "73") db5m.Image = Properties.Resources.blackred;
                if (note == "74") d5m.Image = Properties.Resources.red;
                if (note == "75") eb5m.Image = Properties.Resources.blackred;
                if (note == "76") e5m.Image = Properties.Resources.red;
                if (note == "77") f5m.Image = Properties.Resources.red;
                if (note == "78") gb5m.Image = Properties.Resources.blackred;
                if (note == "79") g5m.Image = Properties.Resources.red;
                if (note == "80") ab5m.Image = Properties.Resources.blackred;
                if (note == "81") a6m.Image = Properties.Resources.red;
                if (note == "82") bb6m.Image = Properties.Resources.blackred;
                if (note == "83") b6m.Image = Properties.Resources.red;
                if (note == "84") c6m.Image = Properties.Resources.red;
                if (note == "85") db6m.Image = Properties.Resources.blackred;
                if (note == "86") d6m.Image = Properties.Resources.red;
                if (note == "87") eb6m.Image = Properties.Resources.blackred;
                if (note == "88") e6m.Image = Properties.Resources.red;
                if (note == "89") f6m.Image = Properties.Resources.red;
                if (note == "90") gb6m.Image = Properties.Resources.blackred;
                if (note == "91") g6m.Image = Properties.Resources.red;
                if (note == "92") ab6m.Image = Properties.Resources.blackred;
                if (note == "93") a7m.Image = Properties.Resources.red;
                if (note == "94") bb7m.Image = Properties.Resources.blackred;
                if (note == "95") b7m.Image = Properties.Resources.red;
                if (note == "96") c7m.Image = Properties.Resources.red;
                if (note == "97") db7m.Image = Properties.Resources.blackred;
                if (note == "98") d7m.Image = Properties.Resources.red;
                if (note == "99") eb7m.Image = Properties.Resources.blackred;
                if (note == "100") e7m.Image = Properties.Resources.red;
                if (note == "101") f7m.Image = Properties.Resources.red;
                if (note == "102") gb7m.Image = Properties.Resources.blackred;
                if (note == "103") g7m.Image = Properties.Resources.red;
                if (note == "104") ab7m.Image = Properties.Resources.blackred;
                if (note == "105") a8m.Image = Properties.Resources.red;
                if (note == "106") bb8m.Image = Properties.Resources.blackred;
                if (note == "107") b8m.Image = Properties.Resources.red;
                if (note == "108") c8m.Image = Properties.Resources.red;

                byte[] message = Encoding.ASCII.GetBytes(note + "_p " + computerId + " " + ipString + "-");
                if (!(offline))
                { 
                    serverStream.Write(message, 0, message.Length);
                    serverStream.Flush();
                    Thread.Sleep(pauseTime);
                }
            }
            else
            {
                if (note == "21") a1.Image = Properties.Resources.red;
                if (note == "22") bb1.Image = Properties.Resources.blackred;
                if (note == "23") b1.Image = Properties.Resources.red;
                if (note == "24") c1.Image = Properties.Resources.red;
                if (note == "25") db1.Image = Properties.Resources.blackred;
                if (note == "26") d1.Image = Properties.Resources.red;
                if (note == "27") eb1.Image = Properties.Resources.blackred;
                if (note == "28") e1.Image = Properties.Resources.red;
                if (note == "29") f1.Image = Properties.Resources.red;
                if (note == "30") gb1.Image = Properties.Resources.blackred;
                if (note == "31") g1.Image = Properties.Resources.red;
                if (note == "32") ab1.Image = Properties.Resources.blackred;
                if (note == "33") a2.Image = Properties.Resources.red;
                if (note == "34") bb2.Image = Properties.Resources.blackred;
                if (note == "35") b2.Image = Properties.Resources.red;
                if (note == "36") c2.Image = Properties.Resources.red;
                if (note == "37") db2.Image = Properties.Resources.blackred;
                if (note == "38") d2.Image = Properties.Resources.red;
                if (note == "39") eb2.Image = Properties.Resources.blackred;
                if (note == "40") e2.Image = Properties.Resources.red;
                if (note == "41") f2.Image = Properties.Resources.red;
                if (note == "42") gb2.Image = Properties.Resources.blackred;
                if (note == "43") g2.Image = Properties.Resources.red;
                if (note == "44") ab2.Image = Properties.Resources.blackred;
                if (note == "45") a3.Image = Properties.Resources.red;
                if (note == "46") bb3.Image = Properties.Resources.blackred;
                if (note == "47") b3.Image = Properties.Resources.red;
                if (note == "48") c3.Image = Properties.Resources.red;
                if (note == "49") db3.Image = Properties.Resources.blackred;
                if (note == "50") d3.Image = Properties.Resources.red;
                if (note == "51") eb3.Image = Properties.Resources.blackred;
                if (note == "52") e3.Image = Properties.Resources.red;
                if (note == "53") f3.Image = Properties.Resources.red;
                if (note == "54") gb3.Image = Properties.Resources.blackred;
                if (note == "55") g3.Image = Properties.Resources.red;
                if (note == "56") ab3.Image = Properties.Resources.blackred;
                if (note == "57") a4.Image = Properties.Resources.red;
                if (note == "58") bb4.Image = Properties.Resources.blackred;
                if (note == "59") b4.Image = Properties.Resources.red;
                if (note == "60") c4.Image = Properties.Resources.red;
                if (note == "61") db4.Image = Properties.Resources.blackred;
                if (note == "62") d4.Image = Properties.Resources.red;
                if (note == "63") eb4.Image = Properties.Resources.blackred;
                if (note == "64") e4.Image = Properties.Resources.red;
                if (note == "65") f4.Image = Properties.Resources.red;
                if (note == "66") gb4.Image = Properties.Resources.blackred;
                if (note == "67") g4.Image = Properties.Resources.red;
                if (note == "68") ab4.Image = Properties.Resources.blackred;
                if (note == "69") a5.Image = Properties.Resources.red;
                if (note == "70") bb5.Image = Properties.Resources.blackred;
                if (note == "71") b5.Image = Properties.Resources.red;
                if (note == "72") c5.Image = Properties.Resources.red;
                if (note == "73") db5.Image = Properties.Resources.blackred;
                if (note == "74") d5.Image = Properties.Resources.red;
                if (note == "75") eb5.Image = Properties.Resources.blackred;
                if (note == "76") e5.Image = Properties.Resources.red;
                if (note == "77") f5.Image = Properties.Resources.red;
                if (note == "78") gb5.Image = Properties.Resources.blackred;
                if (note == "79") g5.Image = Properties.Resources.red;
                if (note == "80") ab5.Image = Properties.Resources.blackred;
                if (note == "81") a6.Image = Properties.Resources.red;
                if (note == "82") bb6.Image = Properties.Resources.blackred;
                if (note == "83") b6.Image = Properties.Resources.red;
                if (note == "84") c6.Image = Properties.Resources.red;
                if (note == "85") db6.Image = Properties.Resources.blackred;
                if (note == "86") d6.Image = Properties.Resources.red;
                if (note == "87") eb6.Image = Properties.Resources.blackred;
                if (note == "88") e6.Image = Properties.Resources.red;
                if (note == "89") f6.Image = Properties.Resources.red;
                if (note == "90") gb6.Image = Properties.Resources.blackred;
                if (note == "91") g6.Image = Properties.Resources.red;
                if (note == "92") ab6.Image = Properties.Resources.blackred;
                if (note == "93") a7.Image = Properties.Resources.red;
                if (note == "94") bb7.Image = Properties.Resources.blackred;
                if (note == "95") b7.Image = Properties.Resources.red;
                if (note == "96") c7.Image = Properties.Resources.red;
                if (note == "97") db7.Image = Properties.Resources.blackred;
                if (note == "98") d7.Image = Properties.Resources.red;
                if (note == "99") eb7.Image = Properties.Resources.blackred;
                if (note == "100") e7.Image = Properties.Resources.red;
                if (note == "101") f7.Image = Properties.Resources.red;
                if (note == "102") gb7.Image = Properties.Resources.blackred;
                if (note == "103") g7.Image = Properties.Resources.red;
                if (note == "104") ab7.Image = Properties.Resources.blackred;
                if (note == "105") a8.Image = Properties.Resources.red;
                if (note == "106") bb8.Image = Properties.Resources.blackred;
                if (note == "107") b8.Image = Properties.Resources.red;
                if (note == "108") c8.Image = Properties.Resources.red;
            }
        }

        public void NoteRelease(string note, bool m)
        {
            if (m)
            {
                if (note == "21") a1m.Image = Properties.Resources.fl;
                if (note == "22") bb1m.Image = Properties.Resources.blackkeys;
                if (note == "23") b1m.Image = Properties.Resources.fl;
                if (note == "24") c1m.Image = Properties.Resources.fl;
                if (note == "25") db1m.Image = Properties.Resources.blackkeys;
                if (note == "26") d1m.Image = Properties.Resources.fl;
                if (note == "27") eb1m.Image = Properties.Resources.blackkeys;
                if (note == "28") e1m.Image = Properties.Resources.fl;
                if (note == "29") f1m.Image = Properties.Resources.fl;
                if (note == "30") gb1m.Image = Properties.Resources.blackkeys;
                if (note == "31") g1m.Image = Properties.Resources.fl;
                if (note == "32") ab1m.Image = Properties.Resources.blackkeys;
                if (note == "33") a2m.Image = Properties.Resources.fl;
                if (note == "34") bb2m.Image = Properties.Resources.blackkeys;
                if (note == "35") b2m.Image = Properties.Resources.fl;
                if (note == "36") c2m.Image = Properties.Resources.fl;
                if (note == "37") db2m.Image = Properties.Resources.blackkeys;
                if (note == "38") d2m.Image = Properties.Resources.fl;
                if (note == "39") eb2m.Image = Properties.Resources.blackkeys;
                if (note == "40") e2m.Image = Properties.Resources.fl;
                if (note == "41") f2m.Image = Properties.Resources.fl;
                if (note == "42") gb2m.Image = Properties.Resources.blackkeys;
                if (note == "43") g2m.Image = Properties.Resources.fl;
                if (note == "44") ab2m.Image = Properties.Resources.blackkeys;
                if (note == "45") a3m.Image = Properties.Resources.fl;
                if (note == "46") bb3m.Image = Properties.Resources.blackkeys;
                if (note == "47") b3m.Image = Properties.Resources.fl;
                if (note == "48") c3m.Image = Properties.Resources.fl;
                if (note == "49") db3m.Image = Properties.Resources.blackkeys;
                if (note == "50") d3m.Image = Properties.Resources.fl;
                if (note == "51") eb3m.Image = Properties.Resources.blackkeys;
                if (note == "52") e3m.Image = Properties.Resources.fl;
                if (note == "53") f3m.Image = Properties.Resources.fl;
                if (note == "54") gb3m.Image = Properties.Resources.blackkeys;
                if (note == "55") g3m.Image = Properties.Resources.fl;
                if (note == "56") ab3m.Image = Properties.Resources.blackkeys;
                if (note == "57") a4m.Image = Properties.Resources.fl;
                if (note == "58") bb4m.Image = Properties.Resources.blackkeys;
                if (note == "59") b4m.Image = Properties.Resources.fl;
                if (note == "60") c4m.Image = Properties.Resources.fl;
                if (note == "61") db4m.Image = Properties.Resources.blackkeys;
                if (note == "62") d4m.Image = Properties.Resources.fl;
                if (note == "63") eb4m.Image = Properties.Resources.blackkeys;
                if (note == "64") e4m.Image = Properties.Resources.fl;
                if (note == "65") f4m.Image = Properties.Resources.fl;
                if (note == "66") gb4m.Image = Properties.Resources.blackkeys;
                if (note == "67") g4m.Image = Properties.Resources.fl;
                if (note == "68") ab4m.Image = Properties.Resources.blackkeys;
                if (note == "69") a5m.Image = Properties.Resources.fl;
                if (note == "70") bb5m.Image = Properties.Resources.blackkeys;
                if (note == "71") b5m.Image = Properties.Resources.fl;
                if (note == "72") c5m.Image = Properties.Resources.fl;
                if (note == "73") db5m.Image = Properties.Resources.blackkeys;
                if (note == "74") d5m.Image = Properties.Resources.fl;
                if (note == "75") eb5m.Image = Properties.Resources.blackkeys;
                if (note == "76") e5m.Image = Properties.Resources.fl;
                if (note == "77") f5m.Image = Properties.Resources.fl;
                if (note == "78") gb5m.Image = Properties.Resources.blackkeys;
                if (note == "79") g5m.Image = Properties.Resources.fl;
                if (note == "80") ab5m.Image = Properties.Resources.blackkeys;
                if (note == "81") a6m.Image = Properties.Resources.fl;
                if (note == "82") bb6m.Image = Properties.Resources.blackkeys;
                if (note == "83") b6m.Image = Properties.Resources.fl;
                if (note == "84") c6m.Image = Properties.Resources.fl;
                if (note == "85") db6m.Image = Properties.Resources.blackkeys;
                if (note == "86") d6m.Image = Properties.Resources.fl;
                if (note == "87") eb6m.Image = Properties.Resources.blackkeys;
                if (note == "88") e6m.Image = Properties.Resources.fl;
                if (note == "89") f6m.Image = Properties.Resources.fl;
                if (note == "90") gb6m.Image = Properties.Resources.blackkeys;
                if (note == "91") g6m.Image = Properties.Resources.fl;
                if (note == "92") ab6m.Image = Properties.Resources.blackkeys;
                if (note == "93") a7m.Image = Properties.Resources.fl;
                if (note == "94") bb7m.Image = Properties.Resources.blackkeys;
                if (note == "95") b7m.Image = Properties.Resources.fl;
                if (note == "96") c7m.Image = Properties.Resources.fl;
                if (note == "97") db7m.Image = Properties.Resources.blackkeys;
                if (note == "98") d7m.Image = Properties.Resources.fl;
                if (note == "99") eb7m.Image = Properties.Resources.blackkeys;
                if (note == "100") e7m.Image = Properties.Resources.fl;
                if (note == "101") f7m.Image = Properties.Resources.fl;
                if (note == "102") gb7m.Image = Properties.Resources.blackkeys;
                if (note == "103") g7m.Image = Properties.Resources.fl;
                if (note == "104") ab7m.Image = Properties.Resources.blackkeys;
                if (note == "105") a8m.Image = Properties.Resources.fl;
                if (note == "106") bb8m.Image = Properties.Resources.blackkeys;
                if (note == "107") b8m.Image = Properties.Resources.fl;
                if (note == "108") c8m.Image = Properties.Resources.fl;

                if (!(offline))
                {
                    byte[] message = Encoding.ASCII.GetBytes(note + "_r " + computerId + " " + ipString + "-");
                    serverStream.Write(message, 0, message.Length);
                    serverStream.Flush();
                    Thread.Sleep(pauseTime);
                }
            }
            else
            {
                if (note == "21") a1.Image = Properties.Resources.fl;
                if (note == "22") bb1.Image = Properties.Resources.blackkeys;
                if (note == "23") b1.Image = Properties.Resources.fl;
                if (note == "24") c1.Image = Properties.Resources.fl;
                if (note == "25") db1.Image = Properties.Resources.blackkeys;
                if (note == "26") d1.Image = Properties.Resources.fl;
                if (note == "27") eb1.Image = Properties.Resources.blackkeys;
                if (note == "28") e1.Image = Properties.Resources.fl;
                if (note == "29") f1.Image = Properties.Resources.fl;
                if (note == "30") gb1.Image = Properties.Resources.blackkeys;
                if (note == "31") g1.Image = Properties.Resources.fl;
                if (note == "32") ab1.Image = Properties.Resources.blackkeys;
                if (note == "33") a2.Image = Properties.Resources.fl;
                if (note == "34") bb2.Image = Properties.Resources.blackkeys;
                if (note == "35") b2.Image = Properties.Resources.fl;
                if (note == "36") c2.Image = Properties.Resources.fl;
                if (note == "37") db2.Image = Properties.Resources.blackkeys;
                if (note == "38") d2.Image = Properties.Resources.fl;
                if (note == "39") eb2.Image = Properties.Resources.blackkeys;
                if (note == "40") e2.Image = Properties.Resources.fl;
                if (note == "41") f2.Image = Properties.Resources.fl;
                if (note == "42") gb2.Image = Properties.Resources.blackkeys;
                if (note == "43") g2.Image = Properties.Resources.fl;
                if (note == "44") ab2.Image = Properties.Resources.blackkeys;
                if (note == "45") a3.Image = Properties.Resources.fl;
                if (note == "46") bb3.Image = Properties.Resources.blackkeys;
                if (note == "47") b3.Image = Properties.Resources.fl;
                if (note == "48") c3.Image = Properties.Resources.fl;
                if (note == "49") db3.Image = Properties.Resources.blackkeys;
                if (note == "50") d3.Image = Properties.Resources.fl;
                if (note == "51") eb3.Image = Properties.Resources.blackkeys;
                if (note == "52") e3.Image = Properties.Resources.fl;
                if (note == "53") f3.Image = Properties.Resources.fl;
                if (note == "54") gb3.Image = Properties.Resources.blackkeys;
                if (note == "55") g3.Image = Properties.Resources.fl;
                if (note == "56") ab3.Image = Properties.Resources.blackkeys;
                if (note == "57") a4.Image = Properties.Resources.fl;
                if (note == "58") bb4.Image = Properties.Resources.blackkeys;
                if (note == "59") b4.Image = Properties.Resources.fl;
                if (note == "60") c4.Image = Properties.Resources.fl;
                if (note == "61") db4.Image = Properties.Resources.blackkeys;
                if (note == "62") d4.Image = Properties.Resources.fl;
                if (note == "63") eb4.Image = Properties.Resources.blackkeys;
                if (note == "64") e4.Image = Properties.Resources.fl;
                if (note == "65") f4.Image = Properties.Resources.fl;
                if (note == "66") gb4.Image = Properties.Resources.blackkeys;
                if (note == "67") g4.Image = Properties.Resources.fl;
                if (note == "68") ab4.Image = Properties.Resources.blackkeys;
                if (note == "69") a5.Image = Properties.Resources.fl;
                if (note == "70") bb5.Image = Properties.Resources.blackkeys;
                if (note == "71") b5.Image = Properties.Resources.fl;
                if (note == "72") c5.Image = Properties.Resources.fl;
                if (note == "73") db5.Image = Properties.Resources.blackkeys;
                if (note == "74") d5.Image = Properties.Resources.fl;
                if (note == "75") eb5.Image = Properties.Resources.blackkeys;
                if (note == "76") e5.Image = Properties.Resources.fl;
                if (note == "77") f5.Image = Properties.Resources.fl;
                if (note == "78") gb5.Image = Properties.Resources.blackkeys;
                if (note == "79") g5.Image = Properties.Resources.fl;
                if (note == "80") ab5.Image = Properties.Resources.blackkeys;
                if (note == "81") a6.Image = Properties.Resources.fl;
                if (note == "82") bb6.Image = Properties.Resources.blackkeys;
                if (note == "83") b6.Image = Properties.Resources.fl;
                if (note == "84") c6.Image = Properties.Resources.fl;
                if (note == "85") db6.Image = Properties.Resources.blackkeys;
                if (note == "86") d6.Image = Properties.Resources.fl;
                if (note == "87") eb6.Image = Properties.Resources.blackkeys;
                if (note == "88") e6.Image = Properties.Resources.fl;
                if (note == "89") f6.Image = Properties.Resources.fl;
                if (note == "90") gb6.Image = Properties.Resources.blackkeys;
                if (note == "91") g6.Image = Properties.Resources.fl;
                if (note == "92") ab6.Image = Properties.Resources.blackkeys;
                if (note == "93") a7.Image = Properties.Resources.fl;
                if (note == "94") bb7.Image = Properties.Resources.blackkeys;
                if (note == "95") b7.Image = Properties.Resources.fl;
                if (note == "96") c7.Image = Properties.Resources.fl;
                if (note == "97") db7.Image = Properties.Resources.blackkeys;
                if (note == "98") d7.Image = Properties.Resources.fl;
                if (note == "99") eb7.Image = Properties.Resources.blackkeys;
                if (note == "100") e7.Image = Properties.Resources.fl;
                if (note == "101") f7.Image = Properties.Resources.fl;
                if (note == "102") gb7.Image = Properties.Resources.blackkeys;
                if (note == "103") g7.Image = Properties.Resources.fl;
                if (note == "104") ab7.Image = Properties.Resources.blackkeys;
                if (note == "105") a8.Image = Properties.Resources.fl;
                if (note == "106") bb8.Image = Properties.Resources.blackkeys;
                if (note == "107") b8.Image = Properties.Resources.fl;
                if (note == "108") c8.Image = Properties.Resources.fl;
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            Connect connect = new Connect(computerId, peerIP);
            connect.ShowDialog();
            peerIP = connect.getIP();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            try
            {
                piano = new InputDevice(0);
                piano.StartRecording();
                piano.ChannelMessageReceived += HandleChannelMessageReceived;
                midiText.Text = "Your MIDI device";
                //piano.SysCommonMessageReceived += HandleSysCommonMessageReceived;
                //piano.SysExMessageReceived += HandleSysExMessageReceived;
                //piano.SysRealtimeMessageReceived += HandleSysRealtimeMessageReceived;
                //piano.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("A device ID has been used that is out of range for your system.")) midiText.Text = "No MIDI device detected";
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                piano.StopRecording();
                piano.Close();
                _socketThread.Abort();
            }
            catch { }
        }
    }
}
