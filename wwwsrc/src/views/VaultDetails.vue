<template>
  <div class="vault-details container-fluid">
    <div class="row">

      <div class="col-10">
          <div class="card">
              <div class="card-header">
                 <h3>{{vault.name}}</h3>
                 <!-- TODO finish building out this component -->
              </div>
          </div>
      </div>

    </div>
  </div>
</template>


<script>
export default {
  name: "vault-details",
  data() {
    return {};
  },
  mounted(){
 this.$store.dispatch("getVault", this.$route.params.vaultId)
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>