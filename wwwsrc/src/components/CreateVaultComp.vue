<template>
  <div class="create-vault">
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
            <h4 class="modal-title w-100" id="myModalLabel">Create A Vault</h4>
            <!-- close modal -->
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <!-- NOTE Create Vault forms -->
          <div class="modal-body">
            <!-- Name form -->
            <div class="md-form">
              <input
                type="text"
                id="name"
                placeholder="Vault name..."
                class="form-control validate"
                v-model="newVault.name"
              />
            </div>
            <hr class="bg-danger" />
            <!-- Description form -->
            <div class="md-form">
              <input
                type="text"
                id="description"
                placeholder="Vault description..."
                class="form-control validate"
                v-model="newVault.description"
              />
              <hr class="bg-danger" />
            </div>
          </div>
          <div class="modal-footer justify-content-center">
            <button type="button" class="btn btn-info text-light" data-dismiss="modal">Cancel</button>
            <button
              type="button"
              data-dismiss="modal"
              class="btn btn-danger text-light"
              @click.prevent="createVault()"
            >Create Vault</button>
          </div>
        </div>
      </div>
    </div>
    <!-- Button trigger modal -->
    <button
      type="button"
      class="btn text-info p-0"
      style="font-size:2.6rem; text-shadow: 1px 1px 3px #000000;"
      data-toggle="modal"
      data-target="#fullHeightModalRight"
    >&plus;</button>
    <!-- Full Height Modal Right -->
  </div>
</template>


<script>
export default {
  name: "create-vault",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {},
  methods: {
    async createVault() {
      this.$store.dispatch("createVault", this.newVault);
      this.newVault = {};
    }
  },
  components: {}
};
</script>


<style scoped>
</style>