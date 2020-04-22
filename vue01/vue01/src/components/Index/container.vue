<template>
  <div>
    <el-menu
      :default-active="activeIndex2"
      class="el-menu-demo"
      mode="horizontal"
      @select="handleSelect"
      background-color="#545c64"
      text-color="#fff"
      active-text-color="#ffd04b"
    >
      <el-menu-item index="1">
        <router-link to="/">主页</router-link>
      </el-menu-item>
      <el-submenu index="2">
        <template slot="title">个人中心</template>
        <el-menu-item index="2-1">个人信息</el-menu-item>
        <el-menu-item index="2-2">购物车</el-menu-item>
        <el-menu-item index="2-3">我的订单</el-menu-item>
      </el-submenu>
      <el-menu-item index="3">
        <el-badge :value="12" class="item">消息中心</el-badge>
      </el-menu-item>
      <el-submenu index="4">
        <template slot="title">我上架的商品</template>
        <el-menu-item index="2-1">全部商品</el-menu-item>
        <el-menu-item index="2-2">已被下单</el-menu-item>
        <el-menu-item index="2-3">未被下单</el-menu-item>
        <el-menu-item index="2-4">交易完成</el-menu-item>
      </el-submenu>
      <el-menu-item>
        <router-link to="/login" v-if="user==''">登录</router-link>
        <a v-else>欢迎您! {{user}}</a>
      </el-menu-item>
      <el-menu-item>
        <a v-if="user!=''" @click="QuitLogin()">
          <router-link to="/login">注销登录</router-link>
        </a>
      </el-menu-item>
    </el-menu>
  </div>
</template>

<script>
export default {
  data() {
    return {
      activeIndex: "1",
      activeIndex2: "1",
      user: ""
    };
  },
  methods: {
    handleSelect(key, keyPath) {
      console.log(key, keyPath);
    },
    Login() {
      this.user = this.$store.state.user;
    },
    QuitLogin() {
      this.$store.commit("QuitLogin");
    }
  },
  mounted: function() {
    this.Login();
  }
};
</script>

<style scoped>
</style>