<template>
  <div class="view-keeps-modal text-info">
    <div
      class="modal fade"
      :id="'view-keep-' + kProp.id"
      tabindex="-1"
      role="dialog"
      aria-labelledby="modelTitleId"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Keep
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
          <div class="modal-body">
            <div class="row text-center">
              <div class="col-6 text-center align-self-center">
                <h2>{{ kProp.name }}</h2>

                <h4>
                  {{ kProp.description }}
                </h4>
              </div>

              <div class="col-6">
                <img :src="kProp.img" class="img-fluid" />
              </div>

              <div class="col-12 p-1">
                <button class="btn btn-primary" @click="addToVault">
                  Add to vault
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { logger } from '../utils/Logger'
import $ from 'jquery'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'ViewKeepModal',
  props: {
    kProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
      record: computed(() => AppState.activeKeeps),
      newKeep: {}
    })
    const route = useRoute()
    return {
      state,
      route,
      async addToVault() {
        try {
          $('#add-keep').modal('hide')
          state.newKeep.creator = state.user
          state.newKeep.vaultId = route.params.id
          logger.log(state.newKeep)
          await keepsService.createKeep(state.newkeep)
          state.newKeep = {}
        } catch (error) {
          logger.log(error)
        }
      }
    }
  },
  components: {}
}
</script>
