<template>
  <div>
    <div style="display: flex;justify-content: center;margin-top: 150px">
      <Register></Register>
    </div>
  </div>
</template>

<script>
import Register from "../components/Login/register";
export default {
  name: "register",
  components: {
    Register
  }
};
</script>