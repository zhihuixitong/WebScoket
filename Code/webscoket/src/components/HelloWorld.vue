<template>
  <div>

    <!-- <button @click="send">发消息</button> -->
  </div>
</template>

<script>
  import ws from"nodejs-websocket"
  export default {
    data() {
      return {
        path: "ws://127.0.0.1:30000",
        socket: ""
      }
    },
    mounted() {

          // 初始化
          this.init()


    },
    methods: {
      init: function() {
    console.log(ws)

         let port = 56
            var server = ws.createServer(function(conn){
                console.log(conn)
            }).listen(port)
      },


       serverCallbackFunction(conn)
      {

          console.log(conn)

      //     console.log("Sever connections = ", server.connections.length)
      //     //when a new message has been received.
      //     conn.on("text", function(str){ this.onMesage(str, conn) })

      //     //when a connection has been closed.
      //     conn.on("close", function(code, reason){ this.onClose(conn, code, reason) })

      //     //when a connection meet error.
      //     conn.on("error", function(code, reason){ this.onClose(conn, code, reason); this.onError(code, reason) })

      },

       onMesage(msg, conn)
      {
          console.log("收到信息：", msg)
      },

       onClose(conn, code, reason)
      {
          console.log(conn, "closed", code, reason)
          console.log("Sever connections = ", server.connections.length)
      },

       onError(code, reason)
      {
          console.log("a connection on error:", code , reason)
      },
      open: function() {
        //console.log("socket连接成功")
        this.$emit('Children-HCTClose', 1);
      },
      error: function() {
        //console.log("连接错误")
        this.$emit('Children-HCTClose', -1);
      },
      getMessage: function(msg) {
        // console.log(msg.data)
        this.$emit('Children-HCTMessage', msg.data);
      },
      send: function(data) {
        var PrintSet = JSON.parse(localStorage.getItem("PrintSet"))
        if (PrintSet != null && PrintSet != "") {
          if (PrintSet.IsLocalPrint == "True") {
            //var date = this.getTime();
            // console.log(data)
            if (this.socket.readyState != 3) {
              this.socket.send(data)
            }
          }
        }

      },
      close: function() {
        // console.log("socket已经关闭")
        this.$emit('Children-HCTClose', 0);
      },

      getTime() {
        var date = new Date();
        var seperator1 = "-";
        var seperator2 = ":";
        //以下代码依次是获取当前时间的年月日时分秒
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var strDate = date.getDate();
        var minute = date.getMinutes();
        var hour = date.getHours();
        var second = date.getSeconds();
        //固定时间格式
        if (month >= 1 && month <= 9) {
          month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
          strDate = "0" + strDate;
        }
        if (hour >= 0 && hour <= 9) {
          hour = "0" + hour;
        }
        if (minute >= 0 && minute <= 9) {
          minute = "0" + minute;
        }
        if (second >= 0 && second <= 9) {
          second = "0" + second;
        }
        var currentdate = year + seperator1 + month + seperator1 + strDate +
          " " + hour + seperator2 + minute + seperator2 + second;
        return currentdate;
      }

    },
    destroyed() {

      var PrintSet = JSON.parse(localStorage.getItem("PrintSet"))
      if (PrintSet != null && PrintSet != "") {
        if (PrintSet.IsLocalPrint == "True") {
          //var date = this.getTime();
          // console.log(data)
          // 销毁监听
          this.socket.onclose = this.close
        }
      }

    }
  }
</script>

<style>
</style>
