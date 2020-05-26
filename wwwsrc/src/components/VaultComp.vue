<template>
  <div class="vault col-sm-10 col-lg-3 m-auto">
    <div class="card mb-3" style="box-shadow: 1px 1px 10px #369">
      <!-- TODO drop down elipse for EDIT -->
      <div class="dropdown show" v-if="$auth.user.sub == vaultData.userId">
        <button
          class="bg-transparent border-0"
          href="#"
          role="button"
          id="dropdownMenuLink"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
        >
          <i class="fas fa-ellipsis-h"></i>
        </button>
        <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
          <button
            class="btn text-danger btn-sm ml-4"
            style="font-size: 1.1rem"
            @click="deleteVault()"
            data-toggle="tooltip"
            data-placement="top"
            title="Delete This Vault"
          >Delete Vault</button>
        </div>
      </div>
      <div class="card-title text-center mt-2">
        <h3>{{vaultData.name}}</h3>
        <hr class="w-25 mt-0 bg-danger" />
      </div>
      <div class="card-body">
        <h5>{{vaultData.description}}</h5>
      </div>
      <div class="card-footer text-center mb-1 mx-auto rounded shadow-sm border-0 bg-light">
        <!-- TODO total amount of keeps & create at date -->
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  props: ["vaultData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteVault() {
      Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
      }).then(result => {
        if (result.value) {
          Swal.fire("Deleted!", "Your Vault has been deleted.", "success");
          this.$store.dispatch("deleteVault", this.vaultData.id);
        }
      });
    }
  },
  components: {}
};
</script>


<style scoped>
</style>