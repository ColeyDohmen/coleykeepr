<template>
  <div class="col-6 p-2">
    <div class="">
      <div class="vaultComponent card rounded">
        <router-link :to="{ name: 'VaultDetailsPage', params: { id: vProp.id } }" class="nav-link">
          <h5>{{ vProp.name }}</h5>
          <h5>{{ vProp.description }}</h5>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
// import { logger } from '../utils/Logger'
// import { vaultsService } from '../services/VaultsService'
// import { useRoute } from 'vue-router'

export default {
  name: 'VaultComponent',
  props: {
    vProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    // const Swal = require('sweetalert2')
    // const route = useRoute()
    const state = reactive({

    })
    return {
      state

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
</style>
