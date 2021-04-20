<template>
  <div
    class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center"
  >
    <!-- <img
      src="https://bcw.blob.core.windows.net/public/img/8600856373152463"
      alt="CodeWorks Logo"
    /> -->
    <h1 class="my-5 bg-dark text-light p-3 rounded d-flex align-items-center">
      <span class="mx-2 text-white">Keeps</span>
    </h1>
    <div class="row">
      <div class="col-4 mt-2 p-2" v-for="k in state.keeps" :key="k.id">
        <keep-component :k-prop="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import KeepComponent from '../components/KeepComponent.vue'
export default {
  components: { KeepComponent },
  name: 'Home',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps)
    })
    onMounted(() => keepsService.getKeeps())
    return {
      state
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  text-align: center;
  user-select: none;
  > img {
    height: 200px;
    width: 200px;
  }
}
</style>
