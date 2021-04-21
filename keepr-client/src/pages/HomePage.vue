<template>
  <div
    class="home d-flex flex-column align-items-center masonry-with-columns body"
  >
    <!-- <img
      src="https://bcw.blob.core.windows.net/public/img/8600856373152463"
      alt="CodeWorks Logo"
    /> -->
    <h1 class="my-5 text-light p-3 rounded d-flex align-items-center">
      <span class="mx-2 text-primary">K e e p s</span>
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

body {
  margin: 0;
  padding: 1rem;
}

// .masonry-with-columns {
//   columns: 6 200px;
//   column-gap: 1rem;
//   div {
//     width: 150px;
//     background: #5ae7ec;
//     color: white;
//     margin: 0 1rem 1rem 0;
//     display: inline-block;
//     width: 100%;
//     text-align: center;
//     font-family: system-ui;
//     font-weight: 900;
//     font-size: 2rem;
//   }
//   @for $i from 1 through 36 {
//     div:nth-child(#{$i}) {
//       $h: (random(400) + 100) + px;
//       height: $h;
//       line-height: $h;
//     }
//   }
// }
</style>
