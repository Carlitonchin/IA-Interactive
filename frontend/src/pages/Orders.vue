<script setup>
    import {ref, onMounted} from 'vue'
    const url_get = "https://localhost:7009/orders"

    const orders = ref([])
    const error = ref("")
    const order_status =
    {
        0:"Pending",
        1:"In Progress",
        2:"Completed",
        3:"Delivered",
        4:"Canceled"
    }
    onMounted(()=>
    {
        fetch(url_get,{method:"GET"})
        .then(res=>
        {
            if(res.status >= 200 && res.status < 300)
                res.json().then(res=>orders.value = res)

            else
                res.json().then(err=>error.value = err.error).catch(err=> error.value = "error biding json")

        })
        .catch(err=> error.value = err)
    })
</script>

<template>
<div>
    <p><a href="/">Home</a> | Orders</p>
    <p>{{orders}}</p>
    <a href="new.html">
        <div id="add-order" class="button">Add order</div>
    </a>
    <div id="container-orders">
        <div class="order" v-for="item in orders" :key="item.id">
        <div class="header-order">
            <div class="order-id">
                Order #{{item.id}}
            </div>
            <div class="order-status">
                {{order_status[item.status]}}
            </div>
        </div>

        <div class="order-body">
            <div class="order-products">
                <div class="products-text">Products</div>
                <div class="list-products">
                    <div class="product" v-for="product in item.products" :key="item.id + ' ' + product.product.sku">
                        <div class="product-name">{{product.product.name + ": " + product.cant}}</div>
                    </div>
                </div>
            </div>

            <div class="order-actions">
                <div class="status-change" v-if="item.status < 3">{{order_status[item.status + 1] + " >"}}</div>

                <div class="cancel-order">Cancel</div>
            </div>
        </div>
        </div>
    </div>
    </div>
</template>

<style scoped>
#add-order
{
    width: fit-content;
    margin: auto;
    margin-bottom: 1rem;
}

#container-orders
{
    display: flex;
    flex-wrap: wrap;
}
.order
{
    width: fit-content;
    margin-right: 2rem;
    border: 2px solid black;
}
.header-order
{
    display: flex;
    border-bottom: 1px solid black;
    padding-left: 0.5rem;
    padding-right: 0.5rem;
    padding-bottom: 0.2rem;
    padding-top: 0.2rem;
    align-items: center;
    margin-bottom: 0.2rem;
}

.order-id
{
    margin-right: 4rem;
}

.order-status
{
    background: gray;
    padding: 0.1rem;
    border-radius: 5px;
    color: white;
    font-weight: bold;
    padding: 0.3rem;
}

.order-body
{
    padding: 0.5rem;
    padding-top: 0.1rem;
    display: flex;
    justify-content: space-between;
}

.products-text
{
    border-bottom: 1px solid black;
    margin-bottom: 0.1rem;
}

.order-actions
{
    min-height: 4rem;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: flex-end;
}

.status-change
{
    border: 1px solid black;
    padding: 0.3rem;
    text-align: center;
    cursor: pointer;
    border-radius: 3px;
    width: 100%;
}

.status-change:hover
{
    background: rgba(128, 128, 128, 0.225);
}

.cancel-order
{
    background: red;
    color: white;
    padding: 0.3rem;
    text-align: center;
    width: 100%;
    cursor: pointer;
    border-radius: 3px;
}

.cancel-order:hover
{
    background: rgb(233, 28, 28);
}
</style>
