<script setup>
import { onMounted, ref } from 'vue'

const url = "https://localhost:7009/products"
const products = ref([])

onMounted(() => {
  fetch(url)
  .then(res=>res.json())
  .then(res=>products.value = res)
  .catch(err=> alert(err))
});
</script>

<template>
<div>
    <p><a href="/">Home</a> | Products</p>

    <a href="/products/new.html">Create new product</a>
    <h1>{{products}}</h1>
    </div>
</template>

<style scoped>
a{
    text-decoration: none;
}
</style>
