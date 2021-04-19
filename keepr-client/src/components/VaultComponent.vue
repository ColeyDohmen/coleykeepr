<template>
  <div class="container-fluid">
    <div class="row">
      <div class="vaultComponent col-6 card">
        <h5>{{ vProp.name }}</h5>
        <h5>{{ vProp.description }}</h5>
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
