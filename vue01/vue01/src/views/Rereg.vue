<template>
  <div>
    <div style="display: flex;justify-content: center;margin-top: 150px">
      <ReReg></ReReg>
    </div>
  </div>
</template>

<script>
import ReReg from "../components/Login/rereg";
export default {
  name: "register",
  components: {
    ReReg
  }
};
</script>