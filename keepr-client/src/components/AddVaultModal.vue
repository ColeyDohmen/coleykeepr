<template>
  <div class="AddVaultModal">
    <div
      class="modal fade"
      id="addvault"
      tabindex="-1"
      role="dialog"
      aria-labelledby="modelTitleId"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Add Vault
            </h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <!-- <div class="modal-body"> -->
          <!-- <form @submit.prevent="addVault">
              <div class="form-group">
                <input
                  type="text"
                  name="name"
                  id="name"
                  class="form-control"
                  placeholder="Enter Title..."
                  aria-describedby="helpId"
                  v-model="state.newVault.name"
                />
              </div>
              <div class="form-group">
                <input
                  type="text"
                  name="description"
                  id="description"
                  class="form-control"
                  placeholder="Enter Description..."
                  aria-describedby="helpId"
                  v-model="state.newVault.description"
                />
              </div>
            </form> -->
          <!-- </div> -->
          <div class="modal-footer justify-content-center">
            <button class="btn btn-primary" type="submit">
              <i class="fa fa-plus-square" aria-hidden="true"></i>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'
import $ from 'jquery'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { logger } from '../utils/Logger'
export default {
  name: 'AddVaultModal',
  setup() {
    const state = reactive({
      user: computed(() => AppState.user),
      activeVault: computed(() => AppState.activeVault),
      newVault: {}
    })
    const route = useRoute()
    return {
      state,
      route,
      async addVault() {
        try {
          $('#addvault').modal('hide')
          state.newVault.creator = state.user
          // state.newMaintenance.creatorId = state.user._id
          state.newVault.creatorId = route.params.id
          logger.log(state.newVault)
          await vaultsService.createVault(state.newVault)
          state.newVault = {}
        } catch (error) {
          logger.log(error)
        }
      }
    }
  },
  components: {}
}
</script>
