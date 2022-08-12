<script setup>
    import {ref} from 'vue'
import Notification from '../components/Notification.vue';
    const url = "https://localhost:9999/products/new"

    const sku = ref("")
    const name = ref("")
    const stock = ref(1)

    const error = ref("")

    function handle_submit(e)
    {
        e.preventDefault()
        fetch(url, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(
        {
            name:name.value,
            stock:stock.value,
            sku:sku.value

        })
  })
        .then(res=>{
            if(res.status >= 200 && res.status < 300)
            {
                res.json().then(r =>
                {
                    document.getElementById("products_link").click();
                })
            }
            else
            {
                res.json().then(err => error.value = err.error)
                .catch(err=> error.value = "Error at json binding")
            }
        })
        .catch(err=>error.value = err);

        return false;
    }
</script>

<template>
<Notification>
<div>

    <p><a href="/">Home</a> | <a href="/products/">Products</a> | New Product</p>
    <div id="container">
    <a href="/products/" id="products_link"  style="display:none">Link</a>
<h1>New Product</h1>
<form method="post"  @submit="handle_submit">
<div class="form-item">
    <label for="sku">SKU</label>
    <input type="text" name="sku" id="sku" v-model="sku"/>
</div>

<div class="form-item">
    <label for="name">Name</label>
    <input type="text" name="name" id="name" v-model="name"/>
</div>

<div class="form-item">
    <label for="stock">Stock</label>
    <input type="number" v-model="stock" min="1" name="stock" id="stock"/>
</div>

<input class="button" type="submit" value="Create"/>
</form>
<p style="color:red">{{error}}</p>
</div>

</div>
</Notification>
</template>

<style scoped>

    #container
    {
        display: flex;
        align-items: center;
        justify-content: center;
        flex-direction: column;
    }
    .form-item{
        margin-bottom: 1rem;
    }

    label{
        margin-right: 1rem;
    }
</style>
