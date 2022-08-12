
<script setup>

import Notification from './components/Notification.vue';
</script>

<template>
<Notification>
  <div id="container">
    <div>
    <h1>Welcome to <span id="welcome-span">IA’s Software Engineer Exam</span></h1>
    <h3>I'm Carlos Arrieta, Computer Scientist and Fullstack Developer</h3>
    <p>Email: <a href="mailto:carlozalejandro98@gmail.com">carlozalejandro98@gmail.com</a></p>
    </div>
    <div id="container-buttons">
      <a href="/products/" class="button m1">Products</a>
      <a href="/orders/" class="button m1">Orders</a>
    </div>
  </div>
  </Notification>
</template>

<style scoped>
#container
{
  text-align: center;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  height: 50vh;
  margin-top: 15vh;
}
  #welcome-span{
    color:rgb(222, 35, 35);
  }

  a{
    text-decoration: none;
  }

</style>
