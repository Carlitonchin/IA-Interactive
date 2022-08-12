<script setup>
    import { onMounted, ref } from 'vue';

    const products = ref([])
    const error = ref('')
    const order = ref([])
    const sku_name = {}
    const url_get_products = "https://localhost:7009/products"
    const add_order_url = "https://localhost:7009/orders/new"

    onMounted(()=>
    {
        fetch(url_get_products)
        .then(res=>
        {
            if(res.status >= 200 && res.status < 300)
                res.json().then(res=>
                {
                    for(let i = 0; i < res.length; i++)
                        sku_name[res[i].sku] = res[i].name;

                    products.value = res

                })
            else
                res.json().then(err=> error.value =err.err).catch(err=>error.value ="error binding json")
        })
        .catch(err=> error.value = err)
    })

    function add(e, sku)
    {
        let p = products.value.find(p=>p.sku == sku);
        if(p.stock == 0)
            return;

        let new_order = order.value.filter(o=>o.sku != sku)

        if(new_order.length == order.value.length)
            order.value = order.value.concat([{sku:sku, cant:1}])
        else
            order.value = order.value.map(o=>o.sku == sku ? {sku:sku, cant:o.cant+1} : o)

        products.value = products.value.map(p=>
        {
            if(p.sku == sku)
                p.stock -= 1

            return p;
        })

    }

    function sub(e, sku)
    {
        order.value = order.value.map(o=>
        {
            if(o.sku == sku)
                o.cant--

            return o
        }).filter(o=>o.cant > 0)

        products.value = products.value.map(p=>
        {
            if(p.sku == sku)
                p.stock ++

            return p
        })
    }

    function add_order()
    {
        fetch(add_order_url, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(order.value)
  })
        .then(res=>{
            if(res.status >= 200 && res.status < 300)
            {
                res.json().then(r =>
                {
                    document.getElementById("orders_link").click();
                })
            }
            else
            {
                res.json().then(err => error.value = err.error)
                .catch(err=> error.value = "Error at json binding")
            }
        })
        .catch(err=>error.value = err);

    }

</script>

<template>
<div id="container">
    <a href="/orders/" id="orders_link" style="display:none;"></a>
    <div id="container-order">
        <h3>Order</h3>
        <div v-if="!order.length">No products</div>
        <table>
            <tr
            class="single-product"
            v-for="item in order" :key="item.sku"
            >
                <td>{{sku_name[item.sku] + ": " + item.cant}}</td>
                <td ><div @click="sub(e, item.sku)" class="remove-product minus box">-</div></td>
            </tr>


        </table>

        <div
        v-if="order.length"
        class="button" id="add-order"
        @click="add_order()"
        >Add order</div>
    </div>
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
          <div :id="item.sku">
          {{item.stock}}
          </div>

          </div>
          </td>
          <td class="td-delete">
            <div class="plus box" @click="add(e,item.sku)">+</div>

          </td>
      </tr>
    </table>
    <p v-else style="text-align: center">There are no products</p>

</div>
</template>

<style scoped>

h3
{
    margin: 0;
}

#container-order
{
    margin-bottom: 2rem;
}

#container
{
    text-align: center;
}
a{
    text-decoration: none;
}

.container-product
{
    display: flex;
    align-items: center;
    justify-content: center;
}

.remove-product
{
    margin-left: 0.3rem;
}

#add-order
{
    width: fit-content;
    margin: auto;
    margin-top: 0.5rem;
    cursor: pointer;
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

