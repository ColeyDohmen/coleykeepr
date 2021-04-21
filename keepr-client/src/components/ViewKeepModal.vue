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
                <!-- <button class="btn btn-primary" @click="addToVault">
                  Add to vault
                </button> -->
                <!-- Example single danger button -->
                <div class="btn-group">
                  <button type="button" class="btn btn-primary btn-md dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Add to vault
                  </button>
                  <div class="dropdown-menu">
                    <a class="dropdown-item" href="#">Action</a>
                    <a class="dropdown-item" href="#">Another action</a>
                    <a class="dropdown-item" href="#">Something else here</a>
                    <div class="dropdown-divider"></div>
                    <a class="dropdown-item" href="#">Separated link</a>
                  </div>
                </div>
                <button
                  class="btn btn-danger btn-sm button p-1 mx-2"
                  @click="deleteKeep"
                >
                  <i
                    class="fa fa-minus-square pam-size text-light mt-2 mb-2"

                    aria-hidden="true"
                  ></i>
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
import NotificationsService from '../services/NotificationsService'
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
      props,
      async addToVault() {
        try {
          $('#add-keep').modal('hide')
          state.newKeep.creator = state.user
          state.newKeep.keepId = route.params.id
          logger.log(state.newKeep)
          await keepsService.createKeep(state.newkeep)
          state.newKeep = {}
        } catch (error) {
          logger.log(error)
        }
      },
      async deleteKeep() {
        try {
          if (await NotificationsService.confirmAction()) {
            await keepsService.deleteKeep(props.kProp.id)
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
