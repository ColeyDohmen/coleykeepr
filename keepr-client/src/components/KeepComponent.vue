<template>
  <ViewKeepModal :k-prop="kProp" />
  <div class="keepComponent col-3">
    <div class="row justify-content-center">
      <button
        class="btn btn-primary button-size card-rounded m-1"
        type="button"
        :id="'view-keep-' + kProp.id"
        data-toggle="modal"
        :data-target="'#view-keep-' + kProp.id"
      >
        <i class="fa fa-plus-circle" aria-hidden="true"></i> View Keep
      </button>
    </div>
    <h5>{{ kProp.name }}</h5>
    <div class="col card">
      <img :src="kProp.img" />
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepComponent',
  props: {
    kProp: {
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
