<template>
  <div class="profilepage container-fluid text-center">
    <div class="row-12 text-center">
      <h3>Creator: <b>{{ state.profile.name }}</b></h3>
      <div class="col-12">
        <img class="rounded" :src="state.profile.picture" alt="" />
      </div>
    </div>
    <div class="row">
      <div class="col-12 text-center" v-if="state.vaults != undefined">
        <h2>Vaults:</h2>
        <p>{{ state.vaults[i] }}</p>
        <button
          class="btn btn-outline-primary button-size card-rounded m-1"
          type="button"
          :id="addvault"
          data-toggle="modal"
          data-target="#addvault"
          v-if="state.profile.email === state.user.email"
        >
          <i class="fa fa-plus btn-outline-success" aria-hidden="true"></i> Add
          Vault
        </button>
        <AddVaultModal />
        <vault-component v-for="v in state.vaults" :key="v.id" :v-prop="v" />
      </div>
    </div>
    <div class="row">
      <div class="col-8 mx-3 py-3" v-if="state.keeps != undefined">
        <h2>Keeps:</h2>
        <button
          class="btn btn-outline-primary button-size card-rounded m-1"
          type="button"
          :id="addkeep"
          data-toggle="modal"
          data-target="#addkeep"
          v-if="state.profile.email === state.user.email"
        >
          <i class="fa fa-plus btn-outline-success" aria-hidden="true"></i> Add
          Keep
        </button>
        <AddKeepModal />
        <div class="row">
          <div class="col-4" v-for="k in state.keeps" :key="k.id">
            <keep-component :k-prop="k" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
import { profileService } from '../services/ProfileService'
export default {
  name: 'ProfilePage',
  props: {
    kProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
      profile: computed(() => AppState.profile)
    })
    const route = useRoute()
    onMounted(async() => {
      await profileService.getProfileById(route.params.id)
      await vaultsService.getVaultsByProfileId(route.params.id)
      await keepsService.getKeepsByProfileId(route.params.id)
    //   await vaultsService.getVault(route.params.id)
    //   await keepsService.getKeep(route.params.id)
    }
    )
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
