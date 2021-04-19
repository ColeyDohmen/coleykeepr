<template>
  <div class="vaultComponent col-12 card">
    <h5>{{ vProp.name }}</h5>
    <h5>{{ vProp.description }}</h5>
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
