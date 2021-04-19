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
              <div class="col-12 text-center">
                <h2>{{ kProp.name }}</h2>

                <h4>
                  {{ kProp.description }}
                </h4>
              </div>
              <div class="row">
                <div class="col-6">
                  <img :src="kProp.img" class="img-fluid" />
                </div>
              </div>

              <div class="col-12">
                <button class="btn btn-danger" @click="AddtoVault">
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
export default {
  name: 'ViewKeepModal',
  props: {
    kProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
      record: computed(() => AppState.activeKeeps),
      active: { index: 0 },
      imageData: {},
      path: 'recordsImages',
      files: []
    })
    return {
      state
    }
  },
  components: {}
}
</script>
