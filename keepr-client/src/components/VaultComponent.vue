<template>
  <div class="col-12 p-1">
    <div class="row">
      <div class="vaultComponent col-6 card rounded">
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
export default {
  name: 'VaultComponent',
  props: {
    vProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({

    })
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
</style>
