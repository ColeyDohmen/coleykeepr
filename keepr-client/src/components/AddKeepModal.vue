<template>
  <div class="AddKeepModal">
    <div
      class="modal fade"
      id="addkeep"
      tabindex="-1"
      role="dialog"
      aria-labelledby="modelTitleId"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Add Keep
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
            <form @submit.prevent="addKeep">
              <div class="form-group">
                <input
                  type="text"
                  name="name"
                  id="name"
                  class="form-control"
                  placeholder="Enter Title..."
                  aria-describedby="helpId"
                  v-model="state.newKeep.name"
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
                  v-model="state.newKeep.description"
                />
              </div>
              <div class="form-group">
                <input
                  type="text"
                  name="img"
                  id="img"
                  class="form-control"
                  placeholder="Enter img url..."
                  aria-describedby="helpId"
                  v-model="state.newKeep.img"
                />
              </div>
              <button class="btn btn-primary" type="submit">
                <i class="fa fa-plus-square" aria-hidden="true"></i>
              </button>
            </form>
          </div>
          <div class="modal-footer justify-content-center">
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import $ from 'jquery'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { logger } from '../utils/Logger'
export default {
  name: 'AddKeepModal',
  setup() {
    const state = reactive({
      user: computed(() => AppState.user),
      activeKeep: computed(() => AppState.activeKeep),
      newKeep: {}
    })
    const route = useRoute()
    return {
      state,
      async addKeep() {
        try {
          $('#addkeep').modal('hide')
          state.newKeep.keeps = state.keeps
          state.newKeep.creator = state.user
          state.newKeep.creatorId = route.params.id
          logger.log(state.newKeep)
          await keepsService.createKeep(state.newKeep)
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
