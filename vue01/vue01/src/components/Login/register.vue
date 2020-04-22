<template>
  <div>
    <table>
      <tr>
        <td>用户名</td>
        <td>
          <el-input
            v-model="user.username"
            placeholder="请输入用户名"
            @blur.native.capture="users()"
            @focus="user.userflag = false"
          ></el-input>
        </td>
        <td v-if="user.username==''">
          <el-alert title="请输入用户名" type="error" show-icon></el-alert>
        </td>
        <td v-else-if="user.userflag==true">
          <el-alert title="该用户已存在" type="error" show-icon></el-alert>
        </td>
      </tr>
      <tr>
        <td>密码</td>
        <td>
          <el-input type="password" v-model="user.password" placeholder="请输入密码"></el-input>
        </td>
        <td v-if="user.password==''">
          <el-alert title="请输入密码" type="error" show-icon></el-alert>
        </td>
      </tr>
      <tr>
        <td>确认密码</td>
        <td>
          <el-input type="password" v-model="user.apassword" placeholder="请输入密码"></el-input>
        </td>
        <td v-if="user.password!=user.apassword">
          <el-alert title="两次密码不一致" type="error" show-icon></el-alert>
        </td>
      </tr>
      <tr>
        <td>邮箱</td>
        <td>
          <el-input v-model="user.mail" placeholder="请输入邮箱"></el-input>
        </td>
        <td v-show="show">
          <el-button
            style="width: 210px"
            type="primary"
            @click="mails"
            v-bind:disabled="user.userflag "
          >发送邮箱验证码</el-button>
        </td>
        <td v-show="!show">
          <el-button style="width: 210px" type="primary">{{count}} s后可再次发送</el-button>
        </td>
      </tr>
      <tr>
        <td>验证码</td>
        <td align="right">
          <el-input v-model="user.code" placeholder="请输入验证码"></el-input>
        </td>
      </tr>
      <tr>
        <td colspan="2" align="right">
          <el-button
            style="width: 210px"
            type="primary"
            @click="Register"
            v-bind:disabled="user.userflag"
          >注册</el-button>
        </td>
      </tr>
    </table>
  </div>
</template>


<script>
export default {
  data() {
    return {
      user: {
        username: "",
        password: "",
        apassword: "",
        mail: "",
        userflag: false,
        code: "",
        mailcode: ""
      },
      show: true,
      count: "",
      timer: null
    };
  },
  methods: {
    users() {
      this.$axios({
        methods: "get",
        url: "http://localhost:5000/api/Reusers",
        params: {
          username: this.user.username
        }
      })
        .then(response => {
          this.user.userflag = response.data;
        })
        .catch(error => {
          console.log(error);
        });
    },
    mails() {
      //邮箱格式
      var regEmail = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
      if (!regEmail.test(this.user.mail)) {
        this.$notify({
          title: "错误",
          message: "邮箱格式错误",
          type: "msg"
        });
      } else {
        //请求发送邮件api
        this.$axios({
          method: "get",
          url: "http://localhost:5000/api/Remail",
          params: {
            mail: this.user.mail
          }
        })
          .then(response => {
            if ((response.data = "该邮箱以被注册")) {
              this.$confirm("该邮箱以被注册, 是否找回密码?", "提示", {
                confirmButtonText: "确定",
                cancelButtonText: "取消",
                type: "warning"
              })
                .then(() => {
                  //60秒计时器
                  const TIME_COUNT = 60;
                  if (!this.timer) {
                    this.count = TIME_COUNT;
                    this.show = false;
                    this.timer = setInterval(() => {
                      if (this.count > 0 && this.count <= TIME_COUNT) {
                        this.count--;
                      } else {
                        this.show = true;
                        clearInterval(this.timer);
                        this.timer = null;
                      }
                    }, 1000);
                  }
                  this.$router.push("/Rereg");
                })
                .catch(() => {});
            } else {
              this.user.mailcode = response.data;
              this.$notify({
                title: "信息",
                message: "邮件已发送,请注意查看邮箱信息",
                type: "msg"
              });
            }
          })
          .catch(error => {
            this.$notify({
              title: "错误",
              message: "邮件发送失败,请检查网络",
              type: "msg"
            });
          });
      }
    },
    Register() {
      if (
        this.user.password == this.user.apassword &&
        this.user.username != "" &&
        this.user.password != "" &&
        this.user.mail != "" &&
        this.user.code != ""
      ) {
        if (this.user.code == this.user.mailcode) {
          this.$axios({
            method: "get",
            url: "http://localhost:5000/api/Reg",
            params: {
              username: this.user.username,
              password: this.user.password,
              mail: this.user.mail
            }
          })
            .then(response => {
              if ((response.data = 1)) {
                this.$notify({
                  title: "正确",
                  message: "用户注册成功,请登录",
                  type: "msg"
                });
                this.$router.push({ path: "/login" });
              }
            })
            .catch(error => {
              this.$notify({
                title: "错误",
                message: "用户注册失败",
                type: "msg"
              });
            });
        } else {
          this.$notify({
            title: "错误",
            message: "验证码错误",
            type: "msg"
          });
        }
      }
    }
  }
};
</script>