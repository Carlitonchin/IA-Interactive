<script setup>
import { onMounted, ref } from 'vue'
import Notification from '../components/Notification.vue';

const url = "https://localhost:7009/products"
const url_stock = "https://localhost:7009/products/update-stock"
const delete_url = "https://localhost:7009/products/delete/"

const products = ref([])
const error = ref("")

const sku_product = {}

onMounted(() => {
  fetch(url)
  .then(res=>res.json())
  .then(res=>products.value = res)
  .catch(err=> alert(err))
});

function update_product(sku, cant)
{
  let stock = document.getElementById(sku);

  stock.innerHTML = Number(stock.innerHTML) + cant;

}

function update_stock(e, sku, cant)
{
  fetch(url_stock,
  {
    method: "PUT",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body:JSON.stringify({
        sku:sku,
        cant:cant
      }
      )
  }
  )
  .then(res=>
  {
    if(res.status >= 200 && res.status < 300)
    {
      error.value = ""
      update_product(sku, cant)
    }
    else{
      res.json().then(err=>error.value = err.error).catch(err=>error.value = "error binding json")
    }
  })
  .catch(err=>error.value = err)
}

function delete_product(e, sku)
{
  fetch(delete_url + sku,
  {
    method:"DELETE",
  }
  )
  .then(res=>
  {
    if(res.status >= 200 && res.status < 300)
    {
      products.value = products.value.filter(p=>p.sku != sku)
    }
    else
    {
      res.json().then(err=>error.value = err.error).catch(r=>error.value = "Error binding json")
    }
  })
  .catch(err=> error.value = err)
}

</script>

<template>
<Notification>
<div>
    <p><a href="/">Home</a> | Products</p>
    <p id="error">{{error}}</p>
     <a  href="/products/new.html" >
    <div id="button-create" class="button">
   Create new product
    </div>
    </a>
    <table id="container-products" v-if="products.length">
      <tr id="head">
      <th>SKU</th>
      <th>Name</th>
      <th>Stock</th>
      <th></th>
      </tr>
      <tr v-for="item in products" :key="item.sku" class="tr-product" :id="'tr'+item.sku">
        <td >{{item.sku}}</td>
        <td>{{item.name}}</td>
        <td>
          <div id="container-stock">
          <div class="minus box" @click="update_stock(e,item.sku, -1)">-</div>
          <div :id="item.sku">
          {{item.stock}}
          </div>
          <div class="plus box" @click="update_stock(e,item.sku, 1)">+</div>
          </div>
          </td>
          <td class="td-delete">
            <p @click="delete_product(e, item.sku)" class="delete">Delete</p>

          </td>
      </tr>
    </table>
    <p v-else style="text-align: center">There are no products</p>
    </div>
    </Notification>
</template>

<style scoped>
a{
    text-decoration: none;
}

#error
{
  text-align: center;
  color: red;
}

#button-create
{
  margin: auto;
  width: fit-content;
  margin-bottom: 1rem;
}

table
{
  margin: auto;
}

#head>th
{

  border-bottom: 2px solid black;
  margin: 0;
}

td
{
  padding-left: 3rem;
  padding-right: 3rem;
  text-align: center;
  border-bottom: 1px solid gray;
}

tr:last-child>td
{
  border-bottom: none;
}

#container-stock
{
  display: flex;
  align-items: center;
  justify-content: center;
}

.box
{
  background:black;
  color: white;
  width: 1.5rem;
  height: 1.5rem;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 50%;
  cursor: pointer;
}

.box:hover
{
  background: rgba(0, 0, 0, 0.777);
}

.minus
{
  margin-right: 0.2rem;
}

.plus
{
  margin-left: 0.2rem;
}

.delete
{
  color: red;
  cursor: pointer;
  margin: 0;
}

.td-delete
{
  padding: 0;
}

</style>
