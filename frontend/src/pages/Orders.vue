<script setup>
    import {ref, onMounted, computed} from 'vue'
import Notification from '../components/Notification.vue';
    const url_get = "https://localhost:7009/orders"
    const url_change_status = "https://localhost:7009/orders/change-status/"
    const url_cancel = "https://localhost:7009/orders/cancel/"

    const orders = ref([])
    const error = ref("")
    const filter = ref(-1)

    const orders_filtered = computed(()=>
    {
        return orders.value.filter(o=>filter.value == -1 || o.status == filter.value)
    })

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

    function change_status(e, order_id)
    {
        fetch(url_change_status + order_id,
        {
            method:"PUT",
        }
        )
        .then(res=>
        {
            if(res.status >= 200 && res.status < 300)
            {

                res.json().then(res=>
                {
                    orders.value = orders.value.map(item=>
                    {
                        if(item.id == order_id)
                        {
                                item.status++;

                        }

                        return item;

                    })
                })
            }
            else
                res.json().then(err=>alert("then mal")).catch(err=>error.value = "Error binding json")

        }
        )
        .catch(err=> error.value = err)
    }

    function cancel(e, order_id)
    {
        fetch(url_cancel + order_id,
        {
            method:"PUT",
        }
        )
        .then(res=>
        {
            if(res.status >= 200 && res.status < 300)
            {

                res.json().then(res=>
                {
                    orders.value = orders.value.map(item=>
                    {
                        if(item.id == order_id)
                        {
                                item.status = 4;

                        }

                        return item;

                    })
                })
            }
            else
                res.json().then(err=>alert("then mal")).catch(err=>error.value = "Error binding json")

        }
        )
        .catch(err=> error.value = err)
    }

    function change_filter(e, f)
    {
        filter.value = f
    }

</script>

<template>
<Notification>
    <div>
    <p><a href="/">Home</a> | Orders</p>
    <p>{{error}}</p>
    <a href="new.html">
        <div id="add-order" class="button">Add order</div>
    </a>
    <div id="filters-container">
        <div @click="change_filter(e, -1)" :class="filter == -1 ? 'filter-selected filter':'filter'">All</div>
        <div
        v-for="i in 5" :key="i"
        :class="filter == i-1 ? 'filter-selected filter':'filter'"
        @click="change_filter(e, i-1)"
        >
        {{order_status[i-1]}}
        </div>
    </div>
    <div id="container-orders">
        <div class="order" v-for="item in orders_filtered" :key="item.id">
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

            <div class="order-actions"  v-if="item.status < 3">
                <div @click="change_status(e, item.id)" class="status-change">{{order_status[item.status + 1] + " >"}}</div>

                <div @click="cancel(e, item.id)" class="cancel-order">Cancel</div>
            </div>
            <div v-else-if="item.status != 4" class="order-actions only-cancel">
                 <div @click="cancel(e, item.id)" class="cancel-order">Cancel</div>
            </div>
        </div>
        </div>
    </div>
    </div>
    </Notification>
</template>

<style scoped>

#filters-container
{
    display: flex;
    justify-content: space-between;
    border-bottom: 1px solid black;
    margin-bottom: 1rem;
}
.filter-selected
{
    font-weight: bold;
    color: blue;
    border-bottom: 4px solid blue;
}

.filter
{
width: 100%;
padding-top: 0.5rem;
padding-bottom: 0.5rem;
text-align: center;
cursor: pointer;
}

.filter:hover
{
    background: rgba(128, 128, 128, 0.303);
}

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
    margin-right: 1rem;
    border: 1px solid black;
    padding: 0.1rem;
    border-radius: 3px;
    margin-bottom: 1rem;
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
    padding-left: 0.3rem;
    padding-right: 0.3rem;
    font-weight: 700;
}

.order-actions
{
    min-height: 5rem;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: flex-end;
    margin-left: 4rem;
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

.only-cancel
{
    justify-content: flex-end !important;
}
</style>
