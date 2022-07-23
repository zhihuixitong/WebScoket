using System;
using System.Net.WebSockets;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
       
        static void Main(string[] args)

        {
           /*
            ClientWebSocket _webSocket = new ClientWebSocket();
            CancellationToken _cancellation = new CancellationToken();

            //建立连接
            var url = "ws://111.230.71.75:30000";

             _webSocket.ConnectAsync(new Uri(url), _cancellation);
*/


            // WebSocket();

            启动();

            Console.ReadKey(true);


        }



       static ClientWebSocket 客户端 = new ClientWebSocket();
      static  bool 开关 = true;
        static  async void 启动()
        {
         
            
            await 客户端.ConnectAsync(new Uri("ws://111.230.71.75:30000"), CancellationToken.None);

            byte[] byteArray = System.Text.Encoding.Default.GetBytes("sdfdsfdsf");

            客户端.SendAsync(new ArraySegment<byte>(byteArray), System.Net.WebSockets.WebSocketMessageType.Text, true, new CancellationToken()).Wait();


            //开始监听
           var dd= 客户端.State;



            监听();
        }



       static async void 监听()
        {

            //开始监听
            var dd = 客户端.State;

            Byte[] 缓冲 = new Byte[1000];
            while (开关)
            {
                //开始监听
                var ddjjj = 客户端.State;

                string str = System.Text.Encoding.UTF8.GetString(缓冲);
                string dsdd = BitConverter.ToString(缓冲);
                if (str !=null)
                {
                    var ddd = str; 
                }

                string struuu = System.Text.Encoding.Default.GetString(缓冲);

                WebSocketReceiveResult 结果 = await 客户端.ReceiveAsync(new ArraySegment<Byte>(缓冲), CancellationToken.None);
               //解析(Encoding.Default.GetString(缓冲, 0, 结果.Count));
            }
        }

        void 关闭()
        {
            开关 = false;
            客户端.Abort();
        }




        static async void WebSocket()
        {
            try
            {
                ClientWebSocket _webSocket = new ClientWebSocket();
                CancellationToken _cancellation = new CancellationToken();

                //建立连接
                var url = "ws://111.230.71.75:30000";

                await _webSocket.ConnectAsync(new Uri(url), _cancellation);

                var bsend = new byte[1024];

                await _webSocket.SendAsync(new ArraySegment<byte>(bsend), WebSocketMessageType.Binary, true, _cancellation); //发送数据

                while (true)
                {
                    var result = new byte[1024];

                    await _webSocket.ReceiveAsync(new ArraySegment<byte>(result), new CancellationToken());//接受数据



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
