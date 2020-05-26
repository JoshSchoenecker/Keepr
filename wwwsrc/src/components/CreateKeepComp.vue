<template>
  <div class="create-keep">
    <!-- Full Height Modal Right -->
    <div
      class="modal fade right"
      id="fullHeightModalRight"
      tabindex="-1"
      role="dialog"
      aria-labelledby="myModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-full-height modal-right" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h4 class="modal-title w-100" id="myModalLabel">Create A Keep</h4>
            <!-- close modal -->
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <!-- NOTE Create Keep forms -->
          <div class="modal-body">
            <!-- Name form -->
            <div class="md-form">
              <input
                type="text"
                id="name"
                placeholder="Keep name..."
                class="form-control validate"
                v-model="newKeep.name"
              />
            </div>
            <hr class="bg-danger" />
            <!-- Description form -->
            <div class="md-form">
              <input
                type="text"
                id="description"
                placeholder="Keep description..."
                class="form-control validate"
                v-model="newKeep.description"
              />
              <hr class="bg-danger" />
            </div>
            <!-- Image URL form -->
            <div class="md-form">
              <input
                type="text"
                name="image"
                placeholder="Keep image URL..."
                class="form-control"
                v-model="newKeep.img"
              />
            </div>
          </div>
          <div class="modal-footer justify-content-center">
            <!-- IsPrivate checkbox -->
            <div class="form-check">
              <input type="checkbox" 
              v-model="newKeep.isPrivate" class="form-check-input" id="materialChecked" checked />
              <label class="form-check-label" for="materialChecked">Make this Keep Private</label>
            </div>
            <button type="button" class="btn btn-info text-light" data-dismiss="modal">Cancel</button>
            <button
              type="button"
              data-dismiss="modal"
              class="btn btn-danger text-light"
              @click.prevent="createKeep()"
            >Create Keep</button>
          </div>
        </div>
      </div>
    </div>
    <!-- Button trigger modal -->
    <button
      type="button"
      class="btn text-danger p-0 pl-2 ml-5 "
      style="font-size:2.8rem; text-shadow: 1px 1px 3px #000000;"
      data-toggle="modal"
      data-target="#fullHeightModalRight"
    >&plus;</button>
    <!-- Full Height Modal Right -->
  </div>
</template>


<script>
export default {
  name: "create-keep",
  data() {
    return {
      newKeep: { isPrivate: true}
    };
  },
  computed: {},
  methods: {
    async createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
      this.newKeep = {};
    }
  },
  components: {}
};
</script>


<style scoped>
</style>