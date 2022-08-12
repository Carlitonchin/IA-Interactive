<script setup>
    import {ref, onMounted} from 'vue'
    const url_get = "https://localhost:9999/orders"
    const orders = ref(0)


    function get_orders()
    {
        fetch(url_get,{method:"GET"})
        .then(res=>
        {
            if(res.status >= 200 && res.status < 300)
                res.json().then(res=>
                {
                    let new_orders = res.filter(o=>o.status == 0)
                    if(new_orders.length != orders.value)
                        orders.value = new_orders.length
                })

            else
                res.json().then(err=>error.value = err.error).catch(err=> error.value = "error biding json")

        })
        .catch(err=> error.value = err)

        setTimeout(get_orders, 1000)
    }

    onMounted(()=>
    {
        get_orders();
    })

</script>

<template>
<div>
    <div v-if="orders" id="container-notification">
    <div id="container-msg">
        There are {{orders}} pending orders
        </div>
        <a href="/orders/" id="link">
            Go to orders
        </a>
    </div>
    <slot/>
    </div>
</template>

<style scoped>
#container-notification
{
    background: rgba(24, 183, 24, 0.732);
    text-align: center;
    display: flex;
    justify-content: flex-end;
    padding: 0.5rem;
    align-items: center;
}

#link
{
    z-index: 5;
}

#container-msg
{
    position: absolute;
    width: 100%;
}
</style>
