<template class="container-fluid">
  <div class="about text-center col-12">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
    <div class="col-8 mx-3 py-3">
      <h2>Vaults:</h2>

      <button
        class="btn btn-outline-primary button-size card-rounded m-1"
        type="button"
        :id="addvault"
        data-toggle="modal"
        data-target="#addvault"
      >
        <i class="fa fa-plus btn-outline-success" aria-hidden="true"></i> Add
        Vault
      </button>
      <vault-component v-for="v in state.vaults" :key="v.id" :v-prop="v" />
    </div>
    <div class="row">
      <div class="col-8 mx-3 py-3">
        <h2>Keeps:</h2>
        <button
          class="btn btn-outline-primary button-size card-rounded m-1"
          type="button"
          :id="addkeep"
          data-toggle="modal"
          data-target="#addkeep"
        >
          <i class="fa fa-plus btn-outline-success" aria-hidden="true"></i> Add
          Keep
        </button>
        <AddKeepModal />

        <keep-component v-for="k in state.keeps" :key="k.id" :k-prop="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import VaultComponent from '../components/VaultComponent.vue'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
export default {
  components: { VaultComponent },
  name: 'Account',
  setup() {
    const state = reactive({
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)
    })
    onMounted(async() => {
      await vaultsService.getVaults(),
      await keepsService.getKeeps()
    }
    )
    return {
      account: computed(() => AppState.account),
      state
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
