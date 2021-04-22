<template>
  <div class="vaultPage container-fluid">
    <h2>{{ state.vault.name }}</h2>
    <h3>{{ state.vault.description }}</h3>
    <div class="row">
      <div class="col-4" v-if="state.vault != undefined">
        <button
          class="btn btn-danger button p-2 mx-2"
          @click="deleteVault"
          v-if="state.profile.email === state.user.email"
        >
          <i
            class="fa fa-minus-square pam-size text-light mt-2"

            aria-hidden="true"
          ></i>
        </button>
        <h2>Keeps: {{ state.keeps.length }}</h2>
      </div>
      <div class="row">
        <div class="col-3">
          <keep-component v-for="k in state.keeps" :key="k.id" :k-prop="k" />
          {{ state.keeps.name }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
import NotificationsService from '../services/NotificationsService'
import { logger } from '../utils/Logger'
import router from '../router'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'VaultPage',
  props: {
    vProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const route = useRoute()
    const state = reactive({
      vault: computed(() => AppState.activeVault),
      user: computed(() => AppState.user),
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      vaultKeeps: computed(() => AppState.vaultKeeps)
    })
    onMounted(() => {
      vaultsService.getVault(route.params.id)
      keepsService.getKeepsByVaultId(route.params.id)
    })
    return {
      state,
      props,
      async deleteVault() {
        try {
          if (await NotificationsService.confirmAction()) {
            await vaultsService.deleteVault(route.params.id)
            router.push({ name: 'Home' })
          }
        } catch (error) {
          logger.log(error)
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
</style>
