<template>
  <div class="profilepage container-fluid">
    <!-- {{ state.user.name }} -->
    {{ state.profile.name }}
    Vaults:
    <vault-component v-for="v in state.vaults" :key="v.id" :v-prop="v" />
    Keeps:
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
