<template class="container-fluid">
  <!-- <div class="row">
    <h1 class="my-5 text-light p-3 rounded col-12 align-items-center">
      <span class="mx-2 text-primary">K e e p s</span>
    </h1>
  </div> -->
  <div
    class="card-columns mx-2 my-2"
  >
    <keep-component v-for="k in state.keeps" :key="k.id" :k-prop="k" />
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

// body {
//   margin: 0;
//   padding: 1rem;
// }

// .card-columns {
//   @include media-breakpoint-only(lg) {
//     column-count: 4;
//   }

//   @include media-breakpoint-only(xl) {
//     column-count: 5;
//   }
// }

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
