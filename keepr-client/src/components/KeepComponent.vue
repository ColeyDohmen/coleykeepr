<template>
  <ViewKeepModal :k-prop="kProp" />
  <div class="keepComponent col-4">
    <div class="row justify-content-center">
      <div class="col-5">
        <h4>{{ kProp.name }}</h4>
        <button
          class="btn btn-primary button-size card-rounded m-1"
          type="button"
          :id="'view-keep-' + kProp.id"
          data-toggle="modal"
          :data-target="'#view-keep-' + kProp.id"
        >
          View Keep
        </button>
      </div>
    </div>
    <div class="col-12 card">
      <router-link :to="{ name: 'Account' }" class="nav-link">
        <i class="fa fa-user-circle" aria-hidden="true"></i>
      </router-link>
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
