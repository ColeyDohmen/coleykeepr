<template class="bg-primary card p-2 my-2 mx-2 mt-2">
  <ViewKeepModal :k-prop="kProp" />
  <div class="keepComponent  rounded">
    <div class="justify-content-center">
    </div>
    <div class="containera my-2 mx-2">
      <router-link :to="{ name: 'ProfilePage', params: { id: kProp.creatorId } }" class="nav-link">
        <i class="fa fa-user-circle bottom-right" aria-hidden="true"></i>
      </router-link>
      <img class="rounded" :src="kProp.img" alt="kpropimg" style="width:100%" />
      <h4 class="bottom-left">
        <div
          class="primary button-size card-rounded m-1"
          type="submit"
          :id="'view-keep-' + kProp.id"
          data-toggle="modal"
          :data-target="'#view-keep-' + kProp.id"
        >
          {{ kProp.name }}
          <button
            class="btn btn-danger btn-sm button"
            @click="deleteVaultKeep"
            v-if="isLogin && kProp.creator.email === state.user.email"
          >
            <i
              class="fa fa-minus-square pam-size text-light mt-2 top-right"

              aria-hidden="true"
            ></i>
          </button>
        </div>
      </h4>
      <div>
      </div>
    </div>
  </div>
</template>

<script>
// import { useRoute } from 'vue-router'
import { computed, reactive } from 'vue'
import { logger } from '../utils/Logger'
import { keepsService } from '../services/KeepsService'
import NotificationsService from '../services/NotificationsService'
import { AppState } from '../AppState'
export default {
  name: 'KeepComponent',
  props: {
    kProp: {
      type: Object,
      required: true
    }
  },
  computed: {
    isLogin() {
      return this.$route.name === 'VaultDetailsPage'
    }
  },

  setup(props) {
    const state = reactive({
      user: computed(() => AppState.user),
      profile: computed(() => AppState.profile)

    })
    return {
      state,
      props,
      async deleteVaultKeep() {
        try {
          if (await NotificationsService.confirmAction()) {
            await keepsService.deleteVaultKeep(props.kProp.vaultKeepId)
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
