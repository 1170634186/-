<template>
  <div>
    <Container></Container>
    <Category></Category>
    <SerchBox></SerchBox>
  </div>
</template>

<script>
import Category from "../components/Index/category";
import Container from "../components/Index/container";
import SerchBox from "../components/SearchBox";
export default {
  name: "Home",
  components: {
    Category,
    Container,
    SerchBox
  }
};
</script>

<style scoped>
</style>
