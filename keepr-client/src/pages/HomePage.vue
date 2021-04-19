<template>
  <div
    class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center"
  >
    <img
      src="https://bcw.blob.core.windows.net/public/img/8600856373152463"
      alt="CodeWorks Logo"
    />
    <h1 class="my-5 bg-dark text-light p-3 rounded d-flex align-items-center">
      <span class="mx-2 text-white">Keepr</span>
    </h1>
    <div class="row">
      <p></p>
      <!-- <vault-component v-for="v in state.vaults" :key="v.id" :v-prop="v" /> -->
      <keep-component v-for="k in state.keeps" :key="k.id" :k-prop="k" />
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
