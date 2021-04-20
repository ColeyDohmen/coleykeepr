<template class="bg-primary justify-content-center">
  <ViewKeepModal :k-prop="kProp" />
  <div class="keepComponent bg-primary rounded">
    <div class="justify-content-center">
      <div class="">
      </div>
    </div>
    <div class="col-6 card">
      <div class="containera">
        <router-link :to="{ name: 'ProfilePage', params: { id: kProp.creatorId } }" class="nav-link">
          <i class="fa fa-user-circle bottom-right" aria-hidden="true"></i>
        </router-link>
        <img :src="kProp.img" alt="kpropimg" style="width:100%" />
        <h4 class="bottom-left">
          <div
            class="primary button-size card-rounded m-1"
            type="submit"
            :id="'view-keep-' + kProp.id"
            data-toggle="modal"
            :data-target="'#view-keep-' + kProp.id"
          >
            {{ kProp.name }}
          </div>
        </h4>
      </div>
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

.containera {
  position: relative;
  text-align: center;
  color: white;
}

/* Bottom left text */
.bottom-left {
  position: absolute;
  bottom: 8px;
  left: 16px;
}

.bottom-right {
  position: absolute;
  bottom: 8px;
  right: 16px;
}
</style>
