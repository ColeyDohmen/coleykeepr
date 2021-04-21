<template>
  <div class="vaultPage container-fluid">
    <h2>{{ state.vault.name }}</h2>
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
      profile: computed(() => AppState.profile)
    })
    onMounted(() => {
      vaultsService.getVault(route.params.id)
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
