<template>
  <div>
    <div style="display: flex;justify-content: center;margin-top: 150px">
      <el-card style="width: 350px">
        <div slot="header" class="clearfix">
          <span>登录</span>
        </div>
        <table>
          <tr>
            <td>用户名</td>
            <td>
              <el-input v-model="user.username" placeholder="请输入用户名"></el-input>
            </td>
          </tr>
          <tr>
            <td>密码</td>
            <td>
              <el-input
                type="password"
                v-model="user.password"
                placeholder="请输入密码"
                @keydown.enter.native="doLogin"
              ></el-input>
            </td>
          </tr>
          <tr>
            <td colspan="2" align="right">
              <el-button style="width: 210px" type="primary" @click="doLogin">登录</el-button>
            </td>
          </tr>
          <tr>
            <td colspan="2" align="right">
              <el-button style="width: 210px" type="primary" @click="doRegister">注册</el-button>
            </td>
          </tr>
          <tr>
            <td colspan="2" align="right">
              <el-button style="width: 210px" type="primary" @click="doRegreg">找回密码</el-button>
            </td>
          </tr>
        </table>
      </el-card>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      user: {
        username: "",
        password: ""
      }
    };
  },
  methods: {
    doLogin() {
      this.$axios({
        method: "get",
        url: "http://localhost:5000/api/login",
        params: {
          username: this.user.username,
          password: this.user.password
        }
      })
        .then(response => {
          if (response.data[0].username != null) {
            this.$router.push({ path: "/" });
            this.$store.commit("LOGIN", response.data[0].username);
            this.$notify({
              title: "欢迎",
              message: "" + this.$store.state.user + "",
              type: "msg"
            });
          }
        })
        .catch(error =>
          this.$notify({
            title: "错误",
            message: "用户名或者密码错误",
            type: "msg"
          })
        );
    },
    doRegister() {
      this.$router.push({ path: "/Register" });
    },
    doRegreg() {
      this.$router.push({ path: "/Rereg" });
    }
  }
};
</script>
